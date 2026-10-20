using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-10)]
public class ENT_Player : GameEntity
{
	[Serializable]
	public class PlayerAudioList
	{
		public string name;

		public string group;

		public string set;
	}

	[Serializable]
	public class InteractionSprite
	{
		public string name;

		public Sprite sprite;
	}

	public enum InteractType
	{
		none = 0,
		press = 1,
		grab = 2,
		hold = 3,
		hanging = 4
	}

	public enum PlayerState
	{
		grounded = 0,
		airborne = 1,
		hanging = 2
	}

	[Serializable]
	public class Footsteps
	{
		public string name;

		public float volume = 0.15f;

		[Range(0f, 2f)]
		public float minPitch = 1f;

		[Range(0f, 2f)]
		public float maxPitch = 1f;

		public ObjectMaterial.MaterialType material;

		public List<AudioClip> audio;

		public bool useLandingAudio;

		public List<AudioClip> landingAudio;

		public float landingAudioVolume = 1f;

		public ParticleSystem landingEffect;

		public float friction = 1f;

		public float moveLerp = 1f;

		public float moveSpeed = 1f;
	}

	[Serializable]
	public class Hand
	{
		[Serializable]
		public class HandPoses
		{
			public string id;

			public Sprite sprite;
		}

		public struct HandPhysicsHits
		{
			public Vector3 position;

			public Vector3 direction;

			public RaycastHit directHit;

			public RaycastHit sphereCastHit;

			public RaycastHit[] lineHit;

			public int lineHitCount;

			public Collider[] sphereCheck;

			public int sphereCheckCount;
		}

		public int id;

		private bool moveLocked;

		[Header("Hand Components")]
		public Transform handModel;

		private ViewSway handSway;

		public Hand_Base handBase;

		public Hand_Base accessoryBase;

		public List<Cosmetic_HandItem> currentCosmetics;

		[Space(10f)]
		public Image uiInteract;

		[Space(10f)]
		public Image uiInteractOverlay;

		private bool canInteract = true;

		[Header("Sprites")]
		public SpriteRenderer handSprite;

		public SpriteRenderer handForegroundSprite;

		public List<HandPoses> handPoses;

		[Header("Controls")]
		public string throwButton = "q";

		[Header("Controls")]
		public string fireButton = "Fire1";

		[Header("Interactions")]
		public InteractType interactState;

		public Clickable currentInteract;

		public Clickable holdMemory;

		public Vector3 holdMemoryPosition;

		public InteractHit holdMemoryHit;

		public Transform holdTarget;

		public float memoryTime;

		public float grabWait;

		public float holdTime;

		private float regenWait;

		public Vector3 holdPosition = Vector3.zero;

		public float inventoryMemoryTime;

		public Collider inventoryMemory;

		public float nohandholdsMemoryTime;

		public InteractHit nohandholdsMemory;

		private Vector3 holdVelocity;

		private Vector3 lastHoldPosition;

		[Header("Status")]
		public float dragMult;

		public float gripStrength = 10f;

		public CL_Prop grabTarget;

		[HideInInspector]
		public Inventory.ItemHand inventoryHand;

		public CL_Handhold handhold;

		[HideInInspector]
		public Sprite curBackgroundSprite;

		[HideInInspector]
		public Sprite curForegroundSprite;

		public bool lockHand;

		public float cooldown;

		private float interactSpriteTimer;

		private bool showingCustomInteractionSprite;

		private ENT_Player player;

		private int backgroundSortingOrder;

		private int foregroundSortingOrder;

		public Action<Hand> _OnStartHandInteraction;

		public Action<Hand> _OnEndHandInteraction;

		private int firstQueuedFrom;

		private List<HandPhysicsHits> queuedHits = new List<HandPhysicsHits>();

		private int beginEndCount;

		private List<RaycastHit[]> raycastHitArrayPool = new List<RaycastHit[]>();

		private List<Collider[]> colliderArrayPool = new List<Collider[]>();

		private int raycastHitArrayPoolSize = 8;

		private int colliderArrayPoolSize = 8;

		public void Initialize(ENT_Player p)
		{
			player = p;
			handSway = handModel.gameObject.GetComponent<ViewSway>();
			handSway.Initialize(this);
			uiInteractOverlay = CL_UIManager.instance.interactOverlays[id];
			if (handBase == null)
			{
				handBase = handModel.gameObject.GetComponentInChildren<Hand_Base>();
			}
			if (handBase != null)
			{
				handBase.hand = this;
			}
			if (accessoryBase != null)
			{
				accessoryBase.hand = this;
			}
			if (currentCosmetics == null)
			{
				currentCosmetics = new List<Cosmetic_HandItem>();
			}
			Cosmetic_HandItem cosmeticInHand = CL_CosmeticManager.GetCosmeticInHand(id);
			if (cosmeticInHand != null)
			{
				currentCosmetics.Add(cosmeticInHand);
			}
			backgroundSortingOrder = handSprite.sortingOrder;
			foregroundSortingOrder = handForegroundSprite.sortingOrder;
		}

		public void BeginInteraction()
		{
			if (beginEndCount == 0)
			{
				_OnStartHandInteraction?.Invoke(this);
			}
			beginEndCount++;
		}

		public void EndInteraction(bool endAll = false)
		{
			if (beginEndCount <= 0)
			{
				beginEndCount = 0;
				return;
			}
			beginEndCount--;
			if (endAll)
			{
				beginEndCount = 0;
			}
			if (beginEndCount == 0)
			{
				_OnEndHandInteraction?.Invoke(this);
			}
		}

		public void LateUpdate()
		{
		}

		public void FixedUpdate()
		{
			if (holdTarget != null)
			{
				Vector3 vector = holdTarget.TransformPoint(holdPosition);
				holdVelocity = (lastHoldPosition - vector) / Time.fixedDeltaTime;
				if (handhold != null)
				{
					holdVelocity *= handhold.velocityMult;
					if ((!handhold.gameObject.activeInHierarchy || !handhold.active || !handhold.enabled) && handhold.dropOnInactive)
					{
						DropHand();
					}
				}
				lastHoldPosition = vector;
				DebugMenu.UpdateDebugText("handvel" + id, $"Hand {id} Velocity: {holdVelocity * 10f}");
			}
			handSprite.sortingOrder = backgroundSortingOrder;
			handForegroundSprite.sortingOrder = foregroundSortingOrder;
			if (regenWait > 0f)
			{
				regenWait -= Time.fixedDeltaTime;
			}
			if (showingCustomInteractionSprite)
			{
				if (interactSpriteTimer <= 0f)
				{
					showingCustomInteractionSprite = false;
				}
				interactSpriteTimer = Mathf.Max(interactSpriteTimer - CL_GameManager.GetPlayerPerceivedDeltaTime(), 0f);
			}
			ScaleUpdate();
			if (IsHolding())
			{
				_ = player.cam.transform.position;
				Vector3 vector2 = handModel.position - player.cam.transform.position;
				RaycastHit[] array = Physics.RaycastAll(player.cam.transform.position, vector2.normalized, vector2.magnitude);
				if (array != null && array.Length != 0)
				{
					RaycastHit[] array2 = array;
					foreach (RaycastHit raycastHit in array2)
					{
						ObjectTagger component = raycastHit.collider.GetComponent<ObjectTagger>();
						if (component != null && component.HasTag("InteractBlocker") && IsHolding())
						{
							DropHand();
						}
					}
				}
			}
			EnqueueInteractCast();
		}

		public void UpdateHandPosition(bool fatigueShake = true)
		{
			if ((interactState == InteractType.hanging || interactState == InteractType.grab || interactState == InteractType.hold) && !IsNullOrDestroyed(currentInteract) && GetHandItem() == null)
			{
				Vector3 vector = UnityEngine.Random.insideUnitSphere * (1f - GetGripStrengthPercent() + GetShake() * 10f);
				if (!fatigueShake)
				{
					vector *= 0f;
				}
				handModel.position = currentInteract.GetGameObject().transform.TransformPoint(holdPosition) + vector * 0.02f;
				handModel.rotation = Quaternion.LookRotation(handModel.transform.position - (player.cam.transform.position - player.cam.transform.forward), player.cam.transform.up);
			}
		}

		private RaycastHit[] GetRaycastHitPooledArray()
		{
			RaycastHit[] array = null;
			if (array == null && raycastHitArrayPool.Count > 0)
			{
				List<RaycastHit[]> list = raycastHitArrayPool;
				array = list[list.Count - 1];
				raycastHitArrayPool.RemoveAt(raycastHitArrayPool.Count - 1);
			}
			if (array == null)
			{
				array = new RaycastHit[raycastHitArrayPoolSize];
			}
			return array;
		}

		private void EnqueueInteractCast()
		{
			BeginInteraction();
			int frameCount = Time.frameCount;
			bool queriesHitBackfaces = Physics.queriesHitBackfaces;
			Physics.queriesHitBackfaces = true;
			float interactDistance = player.GetInteractDistance();
			float radius = player.InteractSphereRadius();
			LayerMask interactMask = player.interactMask;
			Transform transform = player.cam.transform;
			HandPhysicsHits item = new HandPhysicsHits
			{
				position = transform.position,
				direction = transform.forward
			};
			bool flag = Physics.Raycast(item.position, item.direction, out item.directHit, interactDistance, interactMask);
			bool flag2 = Physics.SphereCast(item.position, radius, item.direction, out item.sphereCastHit, interactDistance, interactMask);
			if (flag2 && flag)
			{
				Vector3 vector = item.directHit.point - item.sphereCastHit.point;
				RaycastHit[] raycastHitPooledArray = GetRaycastHitPooledArray();
				int lineHitCount = Physics.SphereCastNonAlloc(item.sphereCastHit.point, 0.15f, vector.normalized, raycastHitPooledArray, vector.magnitude, interactMask, QueryTriggerInteraction.Ignore);
				item.lineHit = raycastHitPooledArray;
				item.lineHitCount = lineHitCount;
				if (CL_UIManager.debug)
				{
					CL_DebugView.draw.WireCapsule(item.sphereCastHit.point, item.sphereCastHit.point + vector, 0.15f);
				}
			}
			else if (flag2)
			{
				Vector3 vector = item.position + item.direction * interactDistance - item.sphereCastHit.point;
				RaycastHit[] raycastHitPooledArray2 = GetRaycastHitPooledArray();
				int lineHitCount2 = Physics.SphereCastNonAlloc(item.sphereCastHit.point, 0.15f, vector.normalized, raycastHitPooledArray2, vector.magnitude, interactMask, QueryTriggerInteraction.Ignore);
				item.lineHit = raycastHitPooledArray2;
				item.lineHitCount = lineHitCount2;
				if (CL_UIManager.debug)
				{
					CL_DebugView.draw.WireCapsule(item.sphereCastHit.point, item.sphereCastHit.point + vector, 0.15f, Color.yellow);
				}
			}
			Collider[] array = null;
			if (array == null && colliderArrayPool.Count > 0)
			{
				List<Collider[]> list = colliderArrayPool;
				array = list[list.Count - 1];
				colliderArrayPool.RemoveAt(colliderArrayPool.Count - 1);
			}
			if (array == null)
			{
				array = new Collider[colliderArrayPoolSize];
			}
			int sphereCheckCount = Physics.OverlapSphereNonAlloc(item.directHit.point, 0.1f, array, interactMask);
			item.sphereCheck = array;
			item.sphereCheckCount = sphereCheckCount;
			if (item.lineHit != null)
			{
				int num = 0;
				for (int i = 0; i < item.lineHitCount; i++)
				{
					if (item.lineHit[i].distance == 0f)
					{
						num++;
					}
				}
				if (num > 0)
				{
					int num2 = item.lineHitCount - num;
					RaycastHit[] raycastHitPooledArray3 = GetRaycastHitPooledArray();
					int num3 = 0;
					for (int j = 0; j < num2; j++)
					{
						if (item.lineHit[num3].distance > 0f)
						{
							raycastHitPooledArray3[j] = item.lineHit[num3];
						}
						else
						{
							j--;
						}
						num3++;
					}
					raycastHitArrayPool.Add(item.lineHit);
					item.lineHit = raycastHitPooledArray3;
					item.lineHitCount = num2;
				}
				for (int k = 0; k < item.lineHit.Length; k++)
				{
					_ = item.lineHit[k].point == Vector3.zero;
				}
			}
			if (frameCount - firstQueuedFrom > 1)
			{
				foreach (HandPhysicsHits queuedHit in queuedHits)
				{
					if (queuedHit.lineHit != null)
					{
						raycastHitArrayPool.Add(queuedHit.lineHit);
					}
					if (queuedHit.sphereCheck != null)
					{
						colliderArrayPool.Add(queuedHit.sphereCheck);
					}
				}
				queuedHits.Clear();
				firstQueuedFrom = frameCount;
			}
			queuedHits.Add(item);
			if (queuedHits.Count > 600)
			{
				queuedHits.RemoveAt(0);
			}
			Physics.queriesHitBackfaces = queriesHitBackfaces;
			EndInteraction();
		}

		public List<HandPhysicsHits> GetInteractCasts()
		{
			int frameCount = Time.frameCount;
			if (frameCount - firstQueuedFrom > 1)
			{
				foreach (HandPhysicsHits queuedHit in queuedHits)
				{
					if (queuedHit.lineHit != null)
					{
						raycastHitArrayPool.Add(queuedHit.lineHit);
					}
					if (queuedHit.sphereCheck != null)
					{
						colliderArrayPool.Add(queuedHit.sphereCheck);
					}
				}
				queuedHits.Clear();
				firstQueuedFrom = frameCount;
			}
			EnqueueInteractCast();
			return queuedHits;
		}

		private void ScaleUpdate()
		{
			if (!IsLocked())
			{
				if (IsHolding())
				{
					float value = 1f + (player.cam.fieldOfView - 90f) * player.invCamFovHandScaleAdjust;
					value = Mathf.Clamp(value, 0.6f, 1.2f);
					Vector3 scale = Vector3.one * handSway.scale * value * 0.95f;
					SetScale(scale);
				}
				else
				{
					_ = Vector3.one * handSway.scale;
					SetScale(Vector3.Lerp(handModel.localScale, Vector3.one * handSway.scale, Time.deltaTime * 5f));
				}
			}
		}

		public void SmoothHandScale(float f)
		{
			SetScale(Vector3.Lerp(handModel.localScale, Vector3.one * handSway.scale * f, Time.deltaTime * 5f));
		}

		public bool IsLocked()
		{
			return moveLocked;
		}

		public void SetLocked(bool b)
		{
			moveLocked = b;
			if (moveLocked)
			{
				handSprite.gameObject.layer = LayerMask.NameToLayer("Default");
			}
			else
			{
				handSprite.gameObject.layer = LayerMask.NameToLayer("Player");
			}
		}

		public void MoveTo(Vector3 pos, float blend = 1f)
		{
			handModel.position = Vector3.Lerp(handSway.transform.TransformPoint(handSway.GetAdjustedInitialPosition()), pos, blend);
			handModel.rotation = Quaternion.LookRotation(handModel.position - (player.cam.transform.position - player.cam.transform.forward), player.cam.transform.up);
		}

		public void MoveTo(Vector3 pos, Vector3 scale, float blend = 1f, bool overrideSwayScale = false)
		{
			if (overrideSwayScale)
			{
				SetScale(scale);
			}
			else
			{
				SetScale(handSway.scale * scale);
			}
			MoveTo(pos, blend);
		}

		public void MoveTo(Vector3 pos, Vector3 scale, Quaternion rotation, float blend = 1f, bool overrideSwayScale = false)
		{
			if (overrideSwayScale)
			{
				SetScale(scale);
			}
			else
			{
				SetScale(handSway.scale * scale);
			}
			MoveTo(pos, blend);
			handModel.rotation = rotation;
		}

		private void SetScale(Vector3 scale)
		{
			handModel.localScale = scale;
		}

		public void SetSortingOrder(int background, int foreground = -1)
		{
			handSprite.sortingOrder = background;
			if (foreground != -1)
			{
				handForegroundSprite.sortingOrder = foreground;
			}
		}

		public void DropHand(bool skipWait = false)
		{
			holdMemory = null;
			playerObject.StopInteraction(id, "", !skipWait);
		}

		public void OnLetGo()
		{
			player._OnHandRelease?.Invoke(this);
		}

		public void AddHandWait(float amount = 1f)
		{
			grabWait += amount;
		}

		public void SetHandWait(float amount = 0f)
		{
			grabWait = amount;
		}

		public void SetSprite(Sprite background, Sprite foreground = null)
		{
			curBackgroundSprite = background;
			handSprite.sprite = background;
			curForegroundSprite = foreground;
			handForegroundSprite.sprite = foreground;
		}

		public bool CanUseSpecialPoseSprite(string poseName)
		{
			if (currentCosmetics != null && currentCosmetics.Count > 0)
			{
				bool flag = false;
				foreach (Cosmetic_HandItem currentCosmetic in currentCosmetics)
				{
					if (currentCosmetic.cosmeticData.swapSprites != null && currentCosmetic.cosmeticData.swapSprites.Count > 0)
					{
						flag = true;
					}
					if (currentCosmetic.cosmeticData.allowedSpecialtyPoses != null && currentCosmetic.cosmeticData.allowedSpecialtyPoses.Contains(poseName))
					{
						return true;
					}
				}
				if (flag)
				{
					return false;
				}
			}
			return true;
		}

		public Sprite GetPoseSprite(string poseID)
		{
			foreach (HandPoses handPose in handPoses)
			{
				if (handPose.id == poseID)
				{
					return handPose.sprite;
				}
			}
			return handPoses[0].sprite;
		}

		public void ShowCustomInteractionSprite(Sprite s, float time = 0.01f)
		{
			Sprite cosmeticInteractSprite = GetCosmeticInteractSprite(s);
			if (cosmeticInteractSprite != null)
			{
				s = cosmeticInteractSprite;
			}
			uiInteract.sprite = s;
			uiInteract.gameObject.SetActive(value: true);
			interactSpriteTimer = time;
			showingCustomInteractionSprite = true;
		}

		public void SetInteractionSprite(Sprite s, Sprite o = null)
		{
			if (s == null)
			{
				HideInteractionSprite();
			}
			else
			{
				if (showingCustomInteractionSprite)
				{
					return;
				}
				Sprite cosmeticInteractSprite = GetCosmeticInteractSprite(s);
				if (cosmeticInteractSprite != null)
				{
					s = cosmeticInteractSprite;
				}
				if (o != null)
				{
					Sprite cosmeticInteractSprite2 = GetCosmeticInteractSprite(o);
					if (cosmeticInteractSprite2 != null)
					{
						o = cosmeticInteractSprite2;
					}
				}
				uiInteract.sprite = s;
				if (o != null)
				{
					uiInteractOverlay.gameObject.SetActive(value: true);
					uiInteractOverlay.sprite = o;
				}
				else
				{
					uiInteractOverlay.gameObject.SetActive(value: false);
					uiInteractOverlay.sprite = o;
				}
			}
		}

		public void HideInteractionSprite()
		{
			if (!showingCustomInteractionSprite)
			{
				uiInteract.gameObject.SetActive(value: false);
			}
		}

		public void ShowInteractionSprite()
		{
			uiInteract.gameObject.SetActive(value: true);
		}

		public Sprite GetCosmeticInteractSprite(Sprite s)
		{
			foreach (Cosmetic_HandItem currentCosmetic in currentCosmetics)
			{
				Sprite interactSwap = currentCosmetic.GetInteractSwap(s);
				if (interactSwap != null)
				{
					return interactSwap;
				}
			}
			return null;
		}

		public void RemoveAllCosmetics()
		{
			foreach (Cosmetic_HandItem currentCosmetic in currentCosmetics)
			{
				currentCosmetic.ClearCosmetic();
			}
			currentCosmetics.Clear();
		}

		public ENT_Player GetPlayer()
		{
			return player;
		}

		public ViewSway GetViewSway()
		{
			return handSway;
		}

		public void ShakeHand(float amount)
		{
			handSway.Shake(amount);
		}

		public float GetShake()
		{
			return handSway.GetShake();
		}

		public void RockHand(float amount)
		{
			handSway.Rock(amount);
		}

		public void AddGripStrength(float amount)
		{
			gripStrength = Mathf.Clamp(gripStrength + amount, 0f, player.GetCurrentGripStrengthTimer(id));
		}

		public void SetGripStrength(float amount)
		{
			gripStrength = Mathf.Clamp(amount, 0f, player.GetCurrentGripStrengthTimer(id));
		}

		public void DamageGripStrength(float amount)
		{
			if (!(amount <= 0f))
			{
				gripStrength = Mathf.Clamp(gripStrength - Mathf.Abs(amount), 0f, player.GetCurrentGripStrengthTimer(id));
				float num = 0.25f;
				if (gripStrength < num)
				{
					player.preGripBrokenStamina?.Invoke(this);
				}
				if (gripStrength < num)
				{
					SetGripStrength(0.5f);
					DropHand();
				}
			}
		}

		public void MinGripStrength(float value)
		{
			gripStrength = Mathf.Min(gripStrength, value);
		}

		public float GetGripStrength()
		{
			return gripStrength;
		}

		public float GetGripStrengthMax()
		{
			return player.GetCurrentGripStrengthTimer(id);
		}

		public float GetGripStrengthPercent()
		{
			return gripStrength / GetGripStrengthMax();
		}

		public void DropItem(Vector3 pos)
		{
			if (inventoryHand.HasItem())
			{
				Inventory.instance.DropItemFromHand(pos, id);
			}
		}

		public void DropItem()
		{
			if (inventoryHand.HasItem())
			{
				Inventory.instance.DropItemFromHand(handModel.position, id);
			}
		}

		public void DestroyItem()
		{
			if (inventoryHand.HasItem())
			{
				Inventory.instance.DestroyItemInHand(id);
			}
		}

		public HandItem GetHandItem()
		{
			if (inventoryHand.currentItem == null)
			{
				return null;
			}
			return inventoryHand.currentItem.GetHandItem();
		}

		public void GrabTarget(Transform target, Vector3 worldspacePos)
		{
			lastHoldPosition = worldspacePos;
			holdTarget = target;
			holdPosition = holdTarget.InverseTransformPoint(worldspacePos);
			holdVelocity = Vector3.zero;
			if (!inventoryHand.HasItem())
			{
				handModel.position = worldspacePos;
			}
			OnInteract();
			player._OnHandGrab?.Invoke(this);
		}

		public void GrabHold(Transform target, Vector3 worldspacePos, Clickable.InteractionInfo info = null)
		{
			lastHoldPosition = worldspacePos;
			holdTarget = target;
			holdPosition = holdTarget.InverseTransformPoint(worldspacePos);
			holdVelocity = Vector3.zero;
			handhold = target.GetComponent<CL_Handhold>();
			dragMult = handhold.dragMult;
			interactState = InteractType.hanging;
			player.PlayHandholdSound(handhold.GetMaterialType());
			if (handhold != null)
			{
				currentInteract = handhold;
				if (info == null)
				{
					info = Clickable.InteractionInfo.CreateNewInfo(player, this);
					info.interactionPoint = worldspacePos;
					info.interactionDirection = player.camTransform.forward;
					info.interactionNormal = -player.camTransform.forward;
				}
				handhold.Interact(info);
			}
			if (!inventoryHand.HasItem())
			{
				handModel.position = worldspacePos;
			}
			OnInteract();
			player._OnHandGrab?.Invoke(this);
		}

		public void OffsetHoldPosition(Vector3 offset)
		{
			Vector3 position = holdTarget.TransformPoint(holdPosition) + offset;
			holdPosition = holdTarget.InverseTransformPoint(position);
		}

		public void SetHoldPosition(Vector3 relativePosition)
		{
			holdPosition = relativePosition;
		}

		public void SetWorldHoldPosition(Vector3 position)
		{
			holdPosition = holdTarget.InverseTransformPoint(position);
		}

		public void OffsetLastHoldPosition(Vector3 offset)
		{
			lastHoldPosition += offset;
		}

		public Vector3 GetHoldPosition()
		{
			return holdPosition;
		}

		public Vector3 GetHoldWorldPosition()
		{
			if (holdTarget == null)
			{
				return handModel.position;
			}
			return holdTarget.TransformPoint(holdPosition);
		}

		public float GetDistanceFromCamera()
		{
			return Vector3.Distance(player.camTransform.position, handModel.position);
		}

		public Vector3 GetVelocity()
		{
			if (holdTarget == null)
			{
				return Vector3.zero;
			}
			return holdVelocity;
		}

		public void SetHandOffset(Vector3 offset)
		{
			handSway.OffsetInitialPosition(offset);
		}

		internal bool CanRegenerate()
		{
			return regenWait <= 0f;
		}

		internal void SetRegenWait(float v)
		{
			regenWait = v;
		}

		public bool IsFree()
		{
			if (interactState != InteractType.none)
			{
				return false;
			}
			if (inventoryHand.HasItem())
			{
				return false;
			}
			return true;
		}

		public bool IsHolding()
		{
			if (interactState == InteractType.grab || interactState == InteractType.hanging || interactState == InteractType.hold)
			{
				return true;
			}
			return false;
		}

		public bool IsHanging()
		{
			return interactState == InteractType.hanging;
		}

		public Hand GetOtherHand()
		{
			return ENT_Player.GetPlayer().hands[(id == 0) ? 1u : 0u];
		}

		public void SetCanInteract(bool b)
		{
			canInteract = b;
		}

		public bool CanInteract()
		{
			return canInteract;
		}

		internal Color GetStaminaDrainColor()
		{
			Color result = Color.red;
			if (currentCosmetics != null)
			{
				foreach (Cosmetic_HandItem currentCosmetic in currentCosmetics)
				{
					if (currentCosmetic.cosmeticData.useCustomStaminaColor)
					{
						result = currentCosmetic.GetCustomStaminaColor();
					}
				}
			}
			return result;
		}

		internal Color GetStaminaDrainIconColor()
		{
			Color result = Color.red;
			if (currentCosmetics != null)
			{
				foreach (Cosmetic_HandItem currentCosmetic in currentCosmetics)
				{
					if (currentCosmetic.cosmeticData.useCustomStaminaColor)
					{
						result = currentCosmetic.GetCustomStaminaIconColor();
					}
				}
			}
			return result;
		}

		internal Color GetStaminaDrainOutlineColor()
		{
			Color result = Color.red;
			if (currentCosmetics != null)
			{
				foreach (Cosmetic_HandItem currentCosmetic in currentCosmetics)
				{
					if (currentCosmetic.cosmeticData.useCustomStaminaColor)
					{
						result = currentCosmetic.GetCustomStaminaOutlineColor();
					}
				}
			}
			return result;
		}

		internal Color GetHandOutlineMaskColor()
		{
			Color result = Color.clear;
			if (currentCosmetics != null)
			{
				foreach (Cosmetic_HandItem currentCosmetic in currentCosmetics)
				{
					if (currentCosmetic.cosmeticData.useCustomStaminaColor)
					{
						result = currentCosmetic.GetOutlineMaskColor();
					}
				}
			}
			return result;
		}

		public void OnInteract()
		{
			ScaleUpdate();
		}
	}

	[Serializable]
	public class SaveData
	{
		public List<Perk.PerkSaveData> perks;

		public List<Perk.PerkSaveData> allPerks;

		public List<BuffContainer> buffs;

		public Item[] inventory;

		public Item[] handInventory;

		public Inventory.Pouch.PouchSaveData[] pouchInventory;

		public Inventory.Pouch.PouchSaveData[] pocketInventory;

		public Vector3 positionRelativeToLevel;

		public Quaternion playerRotation;

		public Quaternion playerCameraRotation;

		public int extraJumpsRemaining;

		public int temporaryExtraJumpsRemaining;

		public void SaveDataIntoClass(ENT_Player player)
		{
			perks = new List<Perk.PerkSaveData>();
			allPerks = new List<Perk.PerkSaveData>();
			extraJumpsRemaining = player.extraJumpsRemaining;
			temporaryExtraJumpsRemaining = player.temporaryExtraJumpsRemaining;
			foreach (Perk perk in player.perks)
			{
				perks.Add(Perk.PerkSaveData.GetPerkSaveData(perk));
			}
			foreach (Perk oldPerk in player.oldPerks)
			{
				Debug.Log(oldPerk);
				allPerks.Add(Perk.PerkSaveData.GetPerkSaveData(oldPerk));
			}
			buffs = new List<BuffContainer>();
			foreach (BuffContainer currentBuff in player.curBuffs.currentBuffs)
			{
				buffs.Add(currentBuff);
			}
			player.inventory.RescanInventory();
			List<Item> list = new List<Item>();
			for (int i = 0; i < player.inventory.bagItems.Count; i++)
			{
				bool flag = false;
				foreach (Inventory.Pouch allPouch in player.inventory.GetAllPouches())
				{
					flag |= allPouch.pouchItems.Contains(player.inventory.bagItems[i]);
				}
				if (!flag)
				{
					player.inventory.bagItems[i].Save();
					list.Add(player.inventory.bagItems[i].GetClone());
				}
			}
			inventory = list.ToArray();
			handInventory = new Item[2];
			if (player.inventory.itemHands[0].currentItem != null)
			{
				player.inventory.itemHands[0].currentItem.Save();
				handInventory[0] = player.inventory.itemHands[0].currentItem.GetClone();
			}
			if (player.inventory.itemHands[1].currentItem != null)
			{
				player.inventory.itemHands[1].currentItem.Save();
				handInventory[1] = player.inventory.itemHands[1].currentItem.GetClone();
			}
			(pouchInventory, pocketInventory) = player.inventory.SavePouches();
			if (WorldLoader.initialized)
			{
				Transform transform = WorldLoader.GetCurrentLevelFromBounds().GetLevel().transform;
				positionRelativeToLevel = transform.InverseTransformPoint(player.transform.position);
				playerRotation = Quaternion.Inverse(transform.rotation) * player.transform.rotation;
				playerCameraRotation = player.camTransform.localRotation;
			}
			else
			{
				playerRotation = player.transform.rotation;
				playerCameraRotation = player.camTransform.localRotation;
				positionRelativeToLevel = player.transform.position;
			}
		}

		public Item[] ProcessWipeInventory(ENT_Player player, Item[] checkInventory, CL_SaveManager.SaveState.SaveType type, bool spawnHammerIfMissing = true)
		{
			List<Item> list = new List<Item>();
			bool flag = false;
			if (type != CL_SaveManager.SaveState.SaveType.reset)
			{
				Item[] array;
				if (HasPerk("Perk_AnomalousBonds") && type == CL_SaveManager.SaveState.SaveType.disk)
				{
					array = checkInventory;
					foreach (Item item in array)
					{
						if (!item.HasTag("disk"))
						{
							list.Add(item);
							continue;
						}
						try
						{
							Debug.Log("Copying data from lost floppy.");
							item.SetItemAsset(CL_AssetManager.GetItemObjectPrefab("Item_Floppy_Lost").GetComponent<Item_Object>());
							list.Add(item);
						}
						catch
						{
							Debug.LogError("ERROR: Grabbing Lost Disk for save load failed. Adding Nothing.");
						}
					}
					array = checkInventory;
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i].HasTag("hammer"))
						{
							flag = true;
							break;
						}
					}
					Debug.Log("Player Has Hammer: " + flag);
					if (!flag && spawnHammerIfMissing)
					{
						Item clone = CL_AssetManager.GetAssetGameObject("Item_Hammer").GetComponent<Item_Object>().itemData.GetClone();
						clone.bagPosition = new Vector3(0f, 0f, 1f);
						clone.bagRotation = Quaternion.LookRotation(-player.transform.forward + Vector3.up * 0.5f) * Quaternion.LookRotation(clone.upDirection);
						list.Add(clone);
					}
					return list.ToArray();
				}
				List<Item> list2 = new List<Item>();
				bool flag2 = HasPerk("Perk_AnomalousBonds");
				array = checkInventory;
				foreach (Item item2 in array)
				{
					if (item2.HasTag("savewithdisk") || flag2)
					{
						list2.Add(item2);
					}
				}
				int count = list2.Count;
				while (count-- > 0)
				{
					bool flag3 = false;
					foreach (Inventory.Pouch allPouch in player.inventory.GetAllPouches())
					{
						flag3 |= allPouch.pouchItems.Contains(list2[count]);
					}
					if (flag3)
					{
						list2.RemoveAt(count);
					}
				}
				foreach (Item item4 in list2)
				{
					if (!item4.hasBeenDestroyed)
					{
						list.Add(item4);
					}
				}
				if (type != CL_SaveManager.SaveState.SaveType.disk && (list2 == null || list2.Count == 0))
				{
					array = checkInventory;
					foreach (Item item3 in array)
					{
						if (item3.HasTag("savewithdisk") || flag2)
						{
							list.Add(item3);
						}
					}
				}
			}
			flag = false;
			foreach (Item item5 in list)
			{
				foreach (string itemTag in item5.itemTags)
				{
					Debug.Log(itemTag);
				}
				if (item5.HasTag("hammer"))
				{
					flag = true;
					break;
				}
			}
			if (!flag && spawnHammerIfMissing)
			{
				Debug.Log("Adding Hammer");
				Item clone2 = CL_AssetManager.GetAssetGameObject("Item_Hammer").GetComponent<Item_Object>().itemData.GetClone();
				clone2.bagPosition = new Vector3(0f, 0f, 1f);
				clone2.bagRotation = Quaternion.LookRotation(-player.transform.forward + Vector3.up * 0.5f) * Quaternion.LookRotation(clone2.upDirection);
				list.Add(clone2);
			}
			return list.ToArray();
		}

		public bool HasPerk(string perkID)
		{
			foreach (Perk.PerkSaveData perk in perks)
			{
				if (perk.id == perkID)
				{
					return true;
				}
			}
			return false;
		}

		public void LoadDataIntoPlayer(ENT_Player player, bool loadInventory = true, bool loadPerks = false, bool loadBuffs = false, string type = "disk")
		{
			Debug.Log("Got Here");
			if (loadBuffs)
			{
				player.curBuffs.currentBuffs = buffs;
				player.curBuffs.UpdateBuffs();
				player.extraJumpsRemaining = extraJumpsRemaining;
				player.temporaryExtraJumpsRemaining = temporaryExtraJumpsRemaining;
			}
			if (loadInventory)
			{
				Debug.Log("PLAYERLOAD - Rescanning");
				player.inventory.RescanInventory();
				Debug.Log("PLAYERLOAD - Clearing Inventory Count: " + player.inventory.bagItems.Count);
				player.inventory.ClearInventory();
				List<Item> list = new List<Item>();
				for (int i = 0; i < inventory.Length; i++)
				{
					Debug.Log(inventory[i].itemName);
					inventory[i].Load();
					inventory[i].CopyNonDataFromItemAsset();
					list.Add(inventory[i].GetClone());
				}
				for (int j = 0; j < list.Count; j++)
				{
					Debug.Log("PLAYERLOAD - Item Printout: " + list[j].itemName);
				}
				player.inventory.LoadPouches(pouchInventory, pocketInventory);
				Debug.Log("PLAYERLOAD - Rescanning Inventory");
				player.inventory.RescanInventory();
				Debug.Log("PLAYERLOAD - Loading Items Into Bag");
				player.inventory.LoadItemsIntoBag(list);
				Debug.Log("PLAYERLOAD - Clearing Inventory 0: " + player.inventory.bagItems.Count);
				for (int k = 0; k < 2; k++)
				{
					if (handInventory[k] != null && handInventory[k].prefabName != "")
					{
						handInventory[k].Load();
						handInventory[k].CopyNonDataFromItemAsset();
						player.inventory.AddItemToHand(handInventory[k].GetClone(), player.hands[k]);
					}
				}
				Debug.Log("PLAYERLOAD - Clearing Inventory 0.5: " + player.inventory.bagItems.Count);
				player.inventory.RescanInventory();
			}
			Debug.Log("PLAYERLOAD - Clearing Inventory 1: " + player.inventory.bagItems.Count);
			player.Revive();
			if (loadPerks)
			{
				Debug.Log("PLAYERLOAD - Loading Perks");
				player.RemoveAllPerks();
				Debug.Log(perks.Count);
				foreach (Perk.PerkSaveData perk3 in perks)
				{
					Perk perk = UnityEngine.Object.Instantiate(CL_AssetManager.GetPerkAsset(perk3.id));
					Perk.PerkSaveData.SetPerkSaveData(player.AddPerk(perk, perk3.stackAmount, firstTime: false), perk3);
				}
				player.oldPerks.Clear();
				foreach (Perk.PerkSaveData allPerk in allPerks)
				{
					Perk perk2 = UnityEngine.Object.Instantiate(CL_AssetManager.GetPerkAsset(allPerk.id));
					Perk.PerkSaveData.SetPerkSaveData(perk2, allPerk);
					player.oldPerks.Add(perk2);
				}
			}
			Debug.Log("PLAYERLOAD - Rescanning");
			player.inventory.RescanInventory();
			Debug.Log("Data loaded into player");
			Debug.Log("Clearing Inventory 2: " + player.inventory.bagItems.Count);
		}
	}

	private CL_GameManager gMan;

	public CharacterController cCon;

	public Transform effectsRoot;

	private Dictionary<string, ParticleSystem> playerEffects = new Dictionary<string, ParticleSystem>();

	public Transform inventoryHandRoot;

	public static ENT_Player playerObject;

	private Inventory inventory;

	private float tick;

	[Header("Player stats")]
	public float speed = 1.5f;

	public float sprintSpeed = 2.5f;

	public float crouchSpeed = 0.75f;

	public float swimSpeed = 0.5f;

	public float jumpHeight = 0.5f;

	private float speedMult = 1f;

	private float frameSpeedMult = 1f;

	private bool cutsceneMode;

	public int extraJumps;

	private int extraJumpsRemaining;

	private int temporaryExtraJumpsRemaining;

	private float lastJumpTime = -100f;

	private float timeSinceJumpBoost;

	public Action _OnJump;

	public Action _OnLand;

	public Action _OnGroundedJump;

	public Action _OnClimbJump;

	public Action _OnClimbRest;

	public Action<Hand> _OnHandGrab;

	public Action<Hand> _OnHandRelease;

	public Action<Hand> _OnHandJump;

	private bool sprinting;

	private bool crouching;

	private Vector3 vel;

	private Vector3 curVel;

	[Space(10f)]
	public float standingHeight = 1.5f;

	public float crouchHeight = 0.75f;

	public float crouchTransitionDuration = 0.25f;

	private bool crouchPressed;

	private PlayerState playerState = PlayerState.airborne;

	private Vector2 inputAxis;

	public float healingRate = 0.15f;

	public float healDelay = 0.5f;

	private float healTimer;

	public float breathMax = 10f;

	private float curBreathAmount = 3f;

	private float breathHurtTimer;

	private bool hasOxygen = true;

	private float intoxication;

	public float playerScale = 1.5f;

	public float gripStrengthTimer = 10f;

	private float gripStrengthLossRate = 1f;

	public float climbJumpDrain = 0.5f;

	[Header("Camera")]
	public Camera cam;

	[Header("Camera")]
	public Camera overlayCam;

	public Camera inventoryCam;

	public float invCamFovHeightAdjust;

	public float invCamFovScaleAdjust = 1f;

	public float invCamFovHandScaleAdjust = 1f;

	public Transform camTransform;

	public Transform invRoot;

	public Transform mainCamTarget;

	public CL_CameraControl camRoot;

	public float camMaxY = 88f;

	public float camMinY = -80f;

	private float curFOV = 90f;

	private float sprintFOV = 100f;

	private float camY;

	private float camSpeed = 1f;

	private float smoothedFOV = 90f;

	private float slowFOVAdjust;

	private float camSway;

	[Header("Effects")]
	public ParticleSystem bloodEffect;

	public FX_DecalShared jumpBoostDecal;

	public ParticleSystem jumpBoostEffect;

	public FX_DecalShared goopedDecal;

	private Vector3 currentFixedCameraPosition;

	private Vector3 previousFixedCameraPosition;

	private Vector3 softParentPreviousOffset;

	private Vector3 lastFixedPlayerPosition;

	private Vector3 lastFixedPlayerParentedPosition;

	private Vector3 lastPlayerPosition;

	private Vector3 cameraRotationVelocity;

	private Vector3 cameraQuickRotationVelocity;

	public float headbob = 0.5f;

	public float sprintHeadbob = 0.5f;

	public float sprintHeadbobOffset;

	public float headbobFrequency = 5f;

	public float headbobSprintFrequency = 5f;

	public float headbobSprintSwayFrequency = 6f;

	public float headbobSprintSwayAmount = 0.6f;

	public float headbobSprintSwayOffset;

	public float headbobSwimSwayFrequency = 6f;

	public float headbobSwimSwayAmount = 0.6f;

	public float headbobSwimSwayOffset;

	public float headbobLimpSway;

	public float headbobLimpFrequency = 6f;

	public AnimationCurve headbobLimpSwayCurve;

	private float bobTime;

	public ViewSway.ViewSwayParameters sprintViewSwayParameters = new ViewSway.ViewSwayParameters();

	public ViewSway.ViewSwayParameters itemViewSwayParameters = new ViewSway.ViewSwayParameters();

	public ViewSway.ViewSwayParameters airbornViewSwayParameters = new ViewSway.ViewSwayParameters();

	public ViewSway.ViewSwayParameters longFallViewSwayParameters = new ViewSway.ViewSwayParameters();

	public ViewSway.ViewSwayParameters swimViewSwayParameters = new ViewSway.ViewSwayParameters();

	[Space]
	public FXManager.FXData damageFX;

	public AnimationCurve damageFXCurve;

	public float dragCoefficient = 0.1f;

	public float frictionMultiplier = 50f;

	public float wallfrictionMultiplier = 10f;

	public float swimFrictionMultiplier = 5f;

	private float tempFrictionMult = 1f;

	public float gravity = -9.81f;

	private float gravityMult = 1f;

	private float tempGravityMult = 1f;

	public float wallPushForce = 0.0001f;

	public float coyoteTime = 0.12f;

	private bool wasGrounded = true;

	private bool isGrounded;

	private float forceAirbornTime;

	private bool isSwimming;

	private bool wasSwimming;

	private bool isUnderwater;

	private UT_SwimZone underwaterZone;

	private bool canJumpThisFrame = true;

	private bool isSliding;

	private bool isResting;

	private float timeSinceGrounded;

	private float timeSinceSprinting;

	private Vector3 climbDir = Vector3.up;

	private Vector3 jumpDir = Vector3.up;

	private float hitTime;

	private bool hasGravity = true;

	private Vector3 moveAxis = Vector3.zero;

	private Vector3 hitNormal;

	private Vector3 lastHitNormal;

	private bool hasHit;

	private float lastHitSurfaceTime;

	private ControllerColliderHit cConHit;

	private bool verticalSlide;

	[Space(10f)]
	public float slopeLimit = 45f;

	[Space(10f)]
	public float slopeMax = 89f;

	public float upSlopeLimit = 91f;

	public float slideFriction = 0.3f;

	public float slideSpeed = 0.3f;

	public float airControl = 0.3f;

	public float swimControl = 0.3f;

	private Vector3 lastVel;

	private Vector3 correctedVelocity;

	private SoftParent softParent;

	private bool softParentHasUpdatedPosition;

	public LayerMask interactMask;

	public LayerMask inventoryItemMask;

	public LayerMask jumpMask;

	public LayerMask parentMask;

	public LayerMask stepMask;

	private bool interactRay;

	private bool mouseInteract;

	private bool paused;

	private bool moveLocked;

	private bool camLocked;

	private bool invLocked;

	private bool moveToLocked;

	private bool hideHands;

	private float hideHandsValue;

	private float holdDistance = 1.8f;

	[Space(10f)]
	public float interactDistance = 2f;

	public float propHangForce = 1f;

	public float grabForgive = 0.3f;

	public float inventoryGrabForgive = 0.3f;

	private bool hasJumped;

	private bool forceJump;

	private bool focusToggled;

	[Space(10f)]
	public Hand[] hands = new Hand[2]
	{
		new Hand(),
		new Hand()
	};

	[Space(10f)]
	private bool grabAnywhere;

	public CL_Handhold[] grabAnywhereFakeHandholds;

	private Vector3[] grabAnywherePosition = new Vector3[2];

	private Transform[] grabAnywhereHit = new Transform[2];

	[Header("UI")]
	public List<InteractionSprite> interactionSprites;

	public Dictionary<string, InteractionSprite> uiSpriteDict;

	private bool useInteractWhitelist;

	private List<string> interactWhitelist = new List<string>();

	public SpriteRenderer aimCircle;

	private float transitionTimer;

	private bool transitioning;

	public UT_AudioClipHandler clipHandler;

	public float softLandCutoff = 1.3f;

	public float mediumLandCutoff = 5f;

	public float heavyLandCutoff = 20f;

	[Space(10f)]
	public AudioSource windAudio;

	public float windAudioVelocityMultiplier;

	private bool fallingAudio;

	public AudioSource damageAudio;

	public float damageAudioVolume = 0.8f;

	public AudioSource dyingAudio;

	public float dyingAudioVolume = 0.8f;

	public AnimationCurve dyingAudioCurve;

	private List<AudioSource> audioChannels;

	[Space(10f)]
	public float footstepSpeed = 1f;

	public float footstepCrouchSpeed = 1f;

	public float footstepSprintSpeed = 1f;

	public List<Footsteps> footsteps;

	private Footsteps curFootstep;

	private RaycastHit curFootstepRaycast;

	private float footstepTime;

	private int lastFootstep = -1;

	[Header("Debug")]
	public bool noclip;

	[Header("Debug")]
	public bool fly;

	private bool forceGrabAnywhere;

	private bool wireframes;

	private bool immersive = true;

	private bool showUI = true;

	private bool infiniteStamina;

	private bool godmode;

	private bool infiniteAmmo;

	private bool infiniteCharge;

	private float curFallDistance;

	private bool falling;

	private float ignoreFallDamageTime;

	private float fallStartHeight;

	private float fallHurtTime;

	private float timeSinceLastHit;

	private string lastHitSource = "";

	private Vector3 cameraPosition;

	private Quaternion cameraRotation;

	private float poisonedHurtTime;

	public CapsuleCollider capsuleCollider;

	[Header("Buffs")]
	public List<Perk> perks;

	private List<Perk> oldPerks = new List<Perk>();

	public UI_Perk_Icon perkIconAsset;

	public Transform perkIconHolder;

	[HideInInspector]
	public Action<Hand> preGripBrokenStamina;

	private float oobCounter;

	public Action _OnKill;

	internal Action _OnTeleport;

	private Coroutine currentMoveCoroutine;

	private Vector3 lastMoveToTarget;

	private float lastFrame;

	private int achHandgunMultikillCounter;

	private float achHandgunMultikillTimer;

	public Action<string> _OnEat;

	private bool showDebugInfoPanel;

	private Rect debugWindowRect = new Rect(20f, 20f, 300f, 400f);

	private Vector2 debugScrollPosition;

	private bool forceSoftParent;

	private bool forceSoftParentPreventVelocityTransfer;

	private Dictionary<Perk, UI_Perk_Icon> perkIcons = new Dictionary<Perk, UI_Perk_Icon>();

	public GameObject perkIconBreakAsset;

	private float currentBuffSlowTimeMult = 1f;

	private void AchievementCheck()
	{
		if (CL_GameManager.gamemode.allowHeightAchievements)
		{
			if (CL_GameManager.gMan.GetPlayerBestTravelDistance() > 250f)
			{
				CL_AchievementManager.SetAchievementValue("ACH_250_METERS", b: true);
			}
			if (CL_GameManager.gMan.GetPlayerBestTravelDistance() > 500f)
			{
				CL_AchievementManager.SetAchievementValue("ACH_500_METERS", b: true);
			}
			if (CL_GameManager.gMan.GetPlayerBestTravelDistance() > 1000f)
			{
				CL_AchievementManager.SetAchievementValue("ACH_1000_METERS", b: true);
			}
			if (CL_GameManager.gMan.GetPlayerBestTravelDistance() > 2000f)
			{
				CL_AchievementManager.SetAchievementValue("ACH_2000_METERS", b: true);
			}
			if (CL_GameManager.gMan.GetPlayerBestTravelDistance() > 5000f)
			{
				CL_AchievementManager.SetAchievementValue("ACH_5000_METERS", b: true);
			}
			if (CL_GameManager.gMan.GetPlayerBestTravelDistance() > 10000f)
			{
				CL_AchievementManager.SetAchievementValue("ACH_10000_METERS", b: true);
			}
		}
	}

	private void KillAchievements(string type)
	{
		switch (type)
		{
		case "steam":
			CL_AchievementManager.SetAchievementValue("ACH_STEAMDEATH", b: true);
			break;
		case "bloodbug":
			CL_AchievementManager.SetAchievementValue("ACH_BLOODBUGKILL", b: true);
			break;
		case "crushed":
			CL_AchievementManager.SetAchievementValue("ACH_CRUSHED", b: true);
			break;
		case "fan":
			CL_AchievementManager.SetAchievementValue("ACH_FANKILL", b: true);
			break;
		case "barnacle":
			CL_AchievementManager.SetAchievementValue("ACH_BARNACLED", b: true);
			break;
		case "teeth":
			CL_AchievementManager.SetAchievementValue("ACH_TEETHKILL", b: true);
			break;
		case "ventthing":
			CL_AchievementManager.SetAchievementValue("ACH_THINGKILL", b: true);
			break;
		}
	}

	private void MouseLook()
	{
		if (softParent.IsParented())
		{
			base.transform.rotation *= softParent.GetRotationalDifference();
		}
		if (!IsMoveLocked() || !IsInputLocked())
		{
			InterpolateCamera();
		}
		if (IsLocked())
		{
			return;
		}
		float num = camSpeed * (1f + curBuffs.GetBuff("addSensitivity"));
		num /= 1f + curBuffs.GetBuff("divideSensitivity");
		float num2 = 0f - InputManager.GetLookVector().y;
		if (SettingsManager.settings.invertY)
		{
			num2 = 0f - num2;
		}
		float num3 = camMaxY;
		if (hands[0].interactState == InteractType.grab || hands[1].interactState == InteractType.grab)
		{
			num3 -= 20f;
		}
		camY = Mathf.Clamp(camY + num2 * num, camMinY, num3);
		intoxication = Mathf.Lerp(intoxication, Mathf.Sin(Time.time * 1.5f) * curBuffs.GetBuff("intoxication"), Time.deltaTime);
		Vector3 vector = new Vector3(camY, InputManager.GetLookVector().x * num, camSway + intoxication);
		DebugMenu.UpdateDebugText("rotationVelocity", "Rotation Velocity: " + cameraRotationVelocity);
		vector += (cameraRotationVelocity + cameraQuickRotationVelocity) * CL_GameManager.GetPlayerPerceivedDeltaTime();
		camY = vector.x;
		base.transform.rotation *= Quaternion.Euler(0f, vector.y, 0f);
		camTransform.localRotation = Quaternion.Euler(vector.x, 0f, vector.z);
		cameraRotationVelocity = Vector3.Lerp(cameraRotationVelocity, Vector3.zero, CL_GameManager.GetPlayerPerceivedDeltaTime() * 3f);
		cameraQuickRotationVelocity = Vector3.Lerp(cameraQuickRotationVelocity, Vector3.zero, CL_GameManager.GetPlayerPerceivedDeltaTime() * 10f);
		if (!IsMoveLocked() && !noclip)
		{
			if (timeSinceGrounded < 0.2f)
			{
				bobTime += Time.deltaTime * Mathf.Clamp(cCon.velocity.magnitude * 0.5f, 0f, 1f);
				Vector3 vector2 = new Vector3(Mathf.Sin(bobTime * 6f) * 0.5f, Mathf.Cos(bobTime * 12f), 0f) * 0.03f * Mathf.Min(cCon.velocity.magnitude, 1f);
				camTransform.localPosition = vector2 * SettingsManager.settings.headbobMultiplier;
			}
			else
			{
				camTransform.localPosition = Vector3.Lerp(camTransform.localPosition, Vector3.zero, Time.deltaTime * 4f);
			}
		}
		else
		{
			camTransform.localPosition = Vector3.Lerp(camTransform.localPosition, Vector3.zero, Time.deltaTime * 4f);
			SetCameraFov(smoothedFOV);
		}
		cameraPosition = camTransform.position;
		cameraRotation = camTransform.rotation;
		softParent.UpdateRotationInfo();
		Hand[] array = hands;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].UpdateHandPosition();
		}
	}

	private void SetCameraFov(float targetFov)
	{
		if (SettingsManager.settings.disableFOVChange)
		{
			targetFov = SettingsManager.settings.playerFOV;
		}
		float fieldOfView = targetFov + curBuffs.GetBuff("addZoomFOV");
		cam.fieldOfView = fieldOfView;
		inventoryCam.fieldOfView = fieldOfView;
		hideHandsValue = Mathf.Lerp(hideHandsValue, (!hideHands) ? 0f : (-0.5f), Time.deltaTime);
		Vector3 vector = Vector3.up * hideHandsValue;
		inventoryHandRoot.localScale = Vector3.one * (1f + (targetFov - 90f) * invCamFovScaleAdjust);
		invRoot.localPosition = Vector3.up * (targetFov - 90f) * invCamFovHeightAdjust + vector;
	}

	private void InterpolateCamera()
	{
		Vector3 vector = Vector3.zero;
		if (lastFixedPlayerPosition != base.transform.position)
		{
			vector = base.transform.position - lastFixedPlayerPosition;
			DebugMenu.UpdateDebugText("interpolationOffset", "Interpolation Offset: " + vector);
		}
		float num = Mathf.Clamp01((Time.time - Time.fixedTime) / Time.fixedDeltaTime);
		if (1f / Time.deltaTime > 50f)
		{
			camRoot.transform.position = Vector3.Lerp(previousFixedCameraPosition, currentFixedCameraPosition, num) + (1f - num) * vector;
		}
		else
		{
			camRoot.transform.position = currentFixedCameraPosition;
		}
	}

	private void CreateCommands()
	{
		CommandConsole.BuildVariableBool(() => ref immersive, "immersive", "Whether or not to show hands and crosshair").NotCheat().Execute(delegate
		{
			inventoryCam.enabled = immersive;
			gMan.uiMan.canvas.gameObject.SetActive(immersive);
		});
		CommandConsole.BuildCommand("noclip", Noclip).Description("(enabled=toggle): Fly around ignoring collision").AutocompleteSingleBool()
			.OverValue(() => noclip);
		CommandConsole.BuildCommand("flight", FlyCommand).Description("(enabled=toggle)").AutocompleteSingleBool()
			.OverValue(() => fly);
		CommandConsole.BuildCommand("wireframes", SetWireframe).Description("(enabled=toggle): Render only triangle edges of game world").AutocompleteSingleBool()
			.OverValue(() => wireframes);
		CommandConsole.BuildCommand("kill", KillCommand).NotCheat().Description("Kill Player");
		CommandConsole.AddCommand("addforcetoplayer", AddForceCommand);
		CommandConsole.BuildCommand("infiniteStamina", InfiniteStaminaCommand).Description("(enabled=toggle): Infinite hand stamina for climbing").AutocompleteSingleBool()
			.OverValue(() => infiniteStamina);
		CommandConsole.BuildCommand("addperk", AddPerkCommand).Description("[perk1 (count=1), perk2 (count=2)...]").AutocompleteCustom(delegate(CommandConsole.CommandAutocomplete autocomplete)
		{
			List<(string, string)> list = new List<(string, string)>();
			foreach (Perk perkAsset3 in CL_AssetManager.GetFullCombinedAssetDatabase().perkAssets)
			{
				string description = perkAsset3.GetDescription(adjusted: true, total: false, includeFlavor: true, includeColorTags: false);
				list.Add((perkAsset3.id.ToLower(), description));
			}
			autocomplete.FromArrayWithDesc(list);
		})
			.AutocompleteValidator(delegate(CommandConsole.CommandValidator validator)
			{
				string id = validator.ArgumentAt(validator.activeArg - 1);
				string text = validator.ArgumentAt(validator.activeArg);
				Perk perkAsset = CL_AssetManager.GetPerkAsset(text);
				Perk perkAsset2 = CL_AssetManager.GetPerkAsset(id);
				if ((0u | ((perkAsset != null) ? 1u : 0u) | ((perkAsset2 != null && int.TryParse(text, out var _)) ? 1u : 0u)) == 0)
				{
					validator.Reject();
				}
			});
		CommandConsole.BuildCommand("addbuff", AddBuffCommand).Description("[decay rate] [buff1 (amount=1) buff2 (count=1)...]");
		CommandConsole.BuildCommand("removeallbuffs", RemoveAllBuffsCommand);
		CommandConsole.AddCommand("listperks", ListPerks);
		CommandConsole.BuildCommand("clearperks", ClearPerks).Description("Remove all perks from player");
		CommandConsole.BuildCommand("godmode", GodMode).Description("(enabled=toggle): You cannot die").AutocompleteSingleBool()
			.OverValue(() => godmode);
		CommandConsole.BuildCommand("infiniteammo", InfiniteAmmoCommand).Description("(enabled=toggle): Guns have infinite ammo").AutocompleteSingleBool()
			.OverValue(() => infiniteAmmo);
		CommandConsole.BuildCommand("infinitecharge", InfiniteChargeCommand).Description("(enabled=toggle): Most rechargeable items recharge instantly").AutocompleteSingleBool()
			.OverValue(() => infiniteCharge);
		CommandConsole.AddCommand("hands-mobile", SetHandsToMobilePosition, cheat: false);
		CommandConsole.AddCommand("hands-offset", OffsetHandsCommand, cheat: false);
		CommandConsole.AddCommand("addpouch", AddPouchCommand);
		CommandConsole.AddCommand("removepouch", RemovePouchCommand);
		CommandConsole.BuildCommand("hurtplayer", HurtPlayerCommand).Description("[type] [damage] : Damages Player.").OverValue(() => health)
			.AutocompleteCustom(delegate(CommandConsole.CommandAutocomplete autocomplete)
			{
				List<(string, string)> fromWhat = new List<(string, string)>
				{
					("standard", "Basic Damage"),
					("nonlethal", "Does not deal any real damage."),
					("dontkill", "Do not kill the player with this damage.")
				};
				autocomplete.FromArrayWithDesc(fromWhat);
			});
		CommandConsole.BuildCommand("setstamina", SetPlayerStaminaCommand).Description("[0..10 value]: Sets Stamina for both hands").OverValue(() => new float[2]
		{
			hands[0].gripStrength,
			hands[1].gripStrength
		});
		CommandConsole.BuildCommand("climbanywhere", ClimbAnywhereCommand).Description("(enabled=toggle): A guilt-free criminal").AutocompleteSingleBool()
			.OverValue(() => forceGrabAnywhere);
		CommandConsole.BuildVariableBool(() => ref showDebugInfoPanel, "debug-showplayerinfo", "Show or Hide player debug info.");
	}

	public void HurtPlayerCommand(string[] args)
	{
		if (args.Length == 0)
		{
			CommandConsole.Log("Incorrect Syntax: hurtplayer [damage] [optional:type]");
			return;
		}
		float result = 0f;
		if (float.TryParse(args[0], out result))
		{
			string text = "";
			if (args.Length > 1)
			{
				text = args[1];
			}
			CommandConsole.Log($"Hurting player for {result} damage with type {text}.");
			Damage(Damageable.DamageInfo.CreateDamageInfo(result, text));
		}
		else if (args.Length > 1 && float.TryParse(args[1], out result))
		{
			string text2 = "";
			text2 = args[0];
			CommandConsole.Log($"Hurting player for {result} damage with type {text2}.");
			Damage(Damageable.DamageInfo.CreateDamageInfo(result, text2));
		}
	}

	public void SetPlayerStaminaCommand(string[] args)
	{
		float result;
		if (args.Length == 0)
		{
			CommandConsole.Log("Incorrect Syntax: setstamina [amount]");
		}
		else if (float.TryParse(args[0], out result))
		{
			SetGripStrength(result);
		}
	}

	public void ListPerks(string[] args)
	{
		foreach (Perk perkAsset in CL_AssetManager.GetFullCombinedAssetDatabase().perkAssets)
		{
			CommandConsole.Log("Perk: " + perkAsset.id.ToLower());
		}
	}

	public void AddPerkCommand(string[] args)
	{
		for (int i = 0; i < args.Length; i++)
		{
			string text = args[i];
			string s = "";
			if (i < args.Length - 1)
			{
				s = args[i + 1];
			}
			Perk perkAsset = CL_AssetManager.GetPerkAsset(text);
			if (perkAsset == null)
			{
				CommandConsole.Log("Could not find perk " + text);
				continue;
			}
			if (int.TryParse(s, out var result))
			{
				i++;
			}
			else
			{
				result = 1;
			}
			if (result > 0)
			{
				for (int j = 0; j < result; j++)
				{
					AddPerk(perkAsset);
				}
			}
			if (result < 0)
			{
				for (int k = 0; k < -result; k++)
				{
					RemovePerk(perkAsset.id, removeAll: false);
				}
			}
		}
	}

	public void KillCommand(string[] args)
	{
		Kill("", null);
	}

	public void AddForceCommand(string[] args)
	{
		AddForce(new Vector3(float.Parse(args[0]), float.Parse(args[1]), float.Parse(args[2])));
	}

	public void InfiniteStaminaCommand(string[] args)
	{
		if (args.Length == 0)
		{
			infiniteStamina = !infiniteStamina;
		}
		else if (!bool.TryParse(args[0], out infiniteStamina))
		{
			CommandConsole.Log("Unable to parse " + args[0] + " arg needs to be a boolean (true/false/0/1).");
			return;
		}
		CommandConsole.Log("Infinite Stamina set to " + infiniteStamina);
	}

	private void ClearPerks(string[] args)
	{
		RemoveAllPerks();
	}

	public void Noclip(string[] args)
	{
		Hand[] array = hands;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GetViewSway().UnsetCustomParameters();
		}
		if (args.Length == 0)
		{
			noclip = !noclip;
		}
		else if (!bool.TryParse(args[0], out noclip))
		{
			CommandConsole.Log("Unable to parse " + args[0] + " arg needs to be a boolean (true/false/0/1).");
			return;
		}
		CommandConsole.Log("Noclip set to " + noclip);
	}

	public void FlyCommand(string[] args)
	{
		if (args.Length == 0)
		{
			fly = !fly;
		}
		else if (!bool.TryParse(args[0], out fly))
		{
			CommandConsole.Log("Unable to parse " + args[0] + " arg needs to be a boolean (true/false/0/1).");
			return;
		}
		CommandConsole.Log("Fly set to " + fly);
	}

	private void SetWireframe(string[] args)
	{
		bool flag = !wireframes;
		if (args.Length != 0 && bool.TryParse(args[0], out var result))
		{
			flag = result;
		}
		wireframes = flag;
		FX_CameraShaderController component = cam.GetComponent<FX_CameraShaderController>();
		if (component != null)
		{
			component.renderWireframes = wireframes;
		}
	}

	public void SetGodMode(bool b)
	{
		godmode = b;
	}

	public bool GetGodMode()
	{
		return godmode;
	}

	public void GodMode(string[] args)
	{
		if (args.Length == 0)
		{
			godmode = !godmode;
			CommandConsole.Log("Godmode set to " + godmode);
		}
		else
		{
			godmode = Convert.ToBoolean(args[0]);
			CommandConsole.Log("Godmode set to " + godmode);
		}
	}

	public void InfiniteAmmoCommand(string[] args)
	{
		if (args.Length == 0)
		{
			infiniteAmmo = !infiniteAmmo;
			CommandConsole.Log("Infinite Ammo set to " + infiniteAmmo);
		}
		else
		{
			infiniteAmmo = Convert.ToBoolean(args[0]);
			CommandConsole.Log("Infinite Ammo set to " + infiniteAmmo);
		}
	}

	public void InfiniteChargeCommand(string[] args)
	{
		if (args.Length == 0)
		{
			infiniteCharge = !infiniteCharge;
			CommandConsole.Log("Infinite Charge set to " + infiniteCharge);
		}
		else
		{
			infiniteCharge = Convert.ToBoolean(args[0]);
			CommandConsole.Log("Infinite Charge set to " + infiniteCharge);
		}
	}

	public bool HasInfiniteAmmo()
	{
		return infiniteAmmo;
	}

	public bool HasInfiniteCharge()
	{
		return infiniteCharge;
	}

	internal void SetHandsToMobilePosition(string[] args)
	{
		float num = 0.12f;
		hands[0].SetHandOffset(Vector3.right * num);
		hands[1].SetHandOffset(Vector3.right * (0f - num));
		inventory.itemHands[0].handInventoryRoot.transform.localPosition += Vector3.right * num;
		inventory.itemHands[1].handInventoryRoot.transform.localPosition += Vector3.right * (0f - num);
	}

	internal void OffsetHandsCommand(string[] args)
	{
		if (args.Length >= 2)
		{
			float result = 0f;
			float result2 = 0f;
			float.TryParse(args[0], out result);
			float.TryParse(args[1], out result2);
			hands[0].SetHandOffset(Vector3.right * result + Vector3.up * result2);
			hands[1].SetHandOffset(Vector3.right * (0f - result) + Vector3.up * result2);
			inventory.itemHands[0].handInventoryRoot.transform.localPosition += Vector3.right * result + Vector3.up * result2;
			inventory.itemHands[1].handInventoryRoot.transform.localPosition += Vector3.right * (0f - result) + Vector3.up * result2;
		}
	}

	public void AddPouchCommand(string[] args)
	{
		inventory.AddExtraPouch();
	}

	public void RemovePouchCommand(string[] args)
	{
		inventory.RemoveExtraPouch();
	}

	public SoftParent GetSoftParent()
	{
		return softParent;
	}

	public void ClimbAnywhereCommand(string[] args)
	{
		if (args.Length == 0)
		{
			forceGrabAnywhere = !forceGrabAnywhere;
		}
		else if (!bool.TryParse(args[0], out forceGrabAnywhere))
		{
			CommandConsole.Log("Unable to parse " + args[0] + " arg needs to be a boolean (true/false/0/1).");
			return;
		}
		CommandConsole.Log("Grab Anywhere set to " + forceGrabAnywhere);
	}

	public void RemoveAllBuffsCommand(string[] args)
	{
		RemoveAllBuffs();
	}

	public void AddBuffCommand(string[] args)
	{
		BuffContainer buffContainer = new BuffContainer();
		buffContainer.buffs = new List<BuffContainer.Buff>();
		float result = 1f;
		int num = 1;
		if (args.Length != 0)
		{
			if (!float.TryParse(args[0], out result))
			{
				num = 0;
			}
			buffContainer.loseRate = result;
			for (int i = num; i < args.Length; i++)
			{
				string id = args[i];
				string s = "";
				if (i < args.Length - 1)
				{
					s = args[i + 1];
				}
				if (float.TryParse(s, out var result2))
				{
					i++;
				}
				else
				{
					result2 = 1f;
				}
				BuffContainer.Buff buff = new BuffContainer.Buff();
				buff.maxAmount = result2;
				buff.id = id;
				buffContainer.buffs.Add(buff);
			}
			AddNewBuff(buffContainer);
		}
		else
		{
			CommandConsole.LogError("Unable to parse, not enough arguments.");
		}
	}

	private void Awake()
	{
		grabAnywhereFakeHandholds[0].transform.parent.parent = null;
		playerObject = this;
		if (clipHandler != null)
		{
			clipHandler.Initialize();
			clipHandler.GetGroup("fatigue").GetSet("level").Play(0f);
		}
		Hand[] array = hands;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].HideInteractionSprite();
		}
		aimCircle.gameObject.SetActive(value: false);
		GetInventory();
		_OnFireTick = (Action)Delegate.Combine(_OnFireTick, new Action(OnFireTick));
	}

	public override void Start()
	{
		base.Start();
		softParent = new SoftParent();
		softParent.Initialize(base.transform, null);
		softParent.lockAngles = new Vector3(0f, 1f, 0f);
		Cursor.lockState = CursorLockMode.Locked;
		gMan = GameObject.Find("GameManager").GetComponent<CL_GameManager>();
		audioChannels = new List<AudioSource> { GetComponent<AudioSource>() };
		for (int i = 0; i < 5; i++)
		{
			audioChannels.Add(base.gameObject.AddComponent<AudioSource>());
			audioChannels[audioChannels.Count - 1].volume = 0.5f;
			audioChannels[i].outputAudioMixerGroup = AudioManager.instance.gameMixer;
		}
		curFootstep = footsteps[0];
		Hand[] array = hands;
		foreach (Hand obj in array)
		{
			obj.gripStrength = gripStrengthTimer;
			obj.Initialize(this);
		}
		uiSpriteDict = new Dictionary<string, InteractionSprite>();
		foreach (InteractionSprite interactionSprite in interactionSprites)
		{
			uiSpriteDict.Add(interactionSprite.name, interactionSprite);
		}
		CreateCommands();
		CL_DebugView.SetCameraTarget(cam);
		foreach (Cosmetic_Voice activeVoiceCosmetic in CL_CosmeticManager.GetActiveVoiceCosmetics())
		{
			clipHandler.overrides.Add(activeVoiceCosmetic.cosmeticData.clipHandlerOverride);
		}
	}

	public override void Update()
	{
		base.Update();
		isUnderwater = UT_SwimZone.IsPositionInAnySwimZone(cam.transform.position, out underwaterZone);
		if (isUnderwater)
		{
			AddEffect("wet", 1f);
		}
		currentBuffSlowTimeMult = Mathf.Lerp(currentBuffSlowTimeMult, GetSlowTimeBuffMult(), Time.unscaledDeltaTime * 12f);
		if (!noclip && WorldLoader.initialized && WorldLoader.instance.GetCurrentLevel() != null)
		{
			M_Level level = WorldLoader.instance.GetCurrentLevel().GetLevel();
			if (level != null && WorldLoader.instance.IsWorldActive())
			{
				Vector3 vector = level.transform.worldToLocalMatrix.MultiplyPoint(base.transform.position);
				if (Vector3.Distance(vector, level.GetLocalBounds().ClosestPoint(vector)) > 500f)
				{
					oobCounter += Time.deltaTime;
					if (oobCounter > 10f)
					{
						oobCounter = 0f;
						Teleport(level.GetSpawnPosition());
						if (CL_UIManager.instance != null)
						{
							CL_UIManager.instance.highscoreHeader.ShowText("You fell out of bounds! Teleporting back to level.");
						}
					}
				}
				else
				{
					oobCounter = 0f;
				}
			}
		}
		forceSoftParent = false;
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		if (!IsLocked())
		{
			curFOV = Mathf.Clamp(curFOV + curBuffs.GetBuff("addFOV"), 60f, 140f);
			smoothedFOV = Mathf.Lerp(smoothedFOV, curFOV + slowFOVAdjust, Time.deltaTime * 5f);
			slowFOVAdjust = Mathf.Lerp(slowFOVAdjust, 0f, Time.deltaTime);
			curFOV = SettingsManager.settings.playerFOV;
			float num = Mathf.Cos(Time.time * 1.5f) * intoxication * 1f;
			SetCameraFov(smoothedFOV + num);
		}
		if (IsMoveLocked())
		{
			previousFixedCameraPosition = currentFixedCameraPosition;
			currentFixedCameraPosition = mainCamTarget.position;
			lastFixedPlayerPosition = base.transform.position;
			if (softParent.IsParented())
			{
				lastFixedPlayerParentedPosition = softParent.GetParentPosition();
			}
		}
		else if (!isFrozen())
		{
			base.transform.localScale = Vector3.one * playerScale * (1f + curBuffs.GetBuff("addPlayerScale"));
			overlayCam.transform.localScale = Vector3.one / (1f + curBuffs.GetBuff("addPlayerScale"));
			cCon.radius = 0.3f + curBuffs.GetBuff("addPlayerWidth");
			Hand[] array = hands;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].FixedUpdate();
			}
			Movement();
			wasSwimming = isSwimming;
			tempFrictionMult = 1f;
			tempGravityMult = 1f;
			correctedVelocity = (base.transform.position - lastFixedPlayerPosition) / Time.fixedDeltaTime;
			lastFixedPlayerPosition = base.transform.position;
			if (softParent.IsParented())
			{
				lastFixedPlayerParentedPosition = softParent.GetParentPosition();
			}
			previousFixedCameraPosition = currentFixedCameraPosition;
			currentFixedCameraPosition = mainCamTarget.position;
			gMan.uiMan.SetVignetteTarget("hurt", 1f - health / maxHealth);
			if (ignoreFallDamageTime > 0f)
			{
				ignoreFallDamageTime -= Time.fixedDeltaTime;
			}
		}
	}

	private void LateUpdate()
	{
		DebugMenu.UpdateDebugText("visibility", "PLAYER VIS: " + GetVisibility());
		softParentHasUpdatedPosition = false;
		float num = damageFXCurve.Evaluate(health / maxHealth);
		FXManager.FXZoneStore fXZoneStore = new FXManager.FXZoneStore();
		fXZoneStore.blend = num;
		fXZoneStore.priority = 16;
		fXZoneStore.data = damageFX;
		FXManager.fxZones.Enqueue(fXZoneStore, 16);
		float num2 = dyingAudioCurve.Evaluate(health / maxHealth);
		damageAudio.volume = Mathf.Lerp(damageAudio.volume, num * damageAudioVolume, CL_GameManager.GetPlayerPerceivedDeltaTime() * 2f);
		dyingAudio.volume = Mathf.Lerp(dyingAudio.volume, num2 * dyingAudioVolume, CL_GameManager.GetPlayerPerceivedDeltaTime() * 2f);
		CL_UIManager.instance.SetVignetteTarget("hidden", 1f - GetVisibility());
		if (gMan.isPaused || IsMoveLocked())
		{
			windAudio.volume = Mathf.Lerp(windAudio.volume, 0f, Time.unscaledDeltaTime * 8f);
		}
		if (gMan.isPaused)
		{
			return;
		}
		bool toggleFocus = SettingsManager.settings.toggleFocus;
		if (toggleFocus && InputManager.GetButton("Focus").Down)
		{
			focusToggled = !focusToggled;
		}
		focusToggled &= toggleFocus;
		if (SettingsManager.settings.toggleCrouch)
		{
			if (InputManager.GetButton("Crouch").Down)
			{
				crouchPressed = !crouchPressed;
			}
		}
		else
		{
			crouchPressed = InputManager.GetButton("Crouch").Pressed;
		}
		if ((!gMan.lockPlayer || !gMan.freecam) && Input.GetKeyDown(KeyCode.F4))
		{
			showUI = !showUI;
			gMan.uiMan.canvas.gameObject.SetActive(showUI);
		}
		if (!isFrozen() && !gMan.lockPlayerInput)
		{
			LandingAudio();
			if (hitTime > 0f)
			{
				hitTime -= Time.deltaTime;
				DebugMenu.UpdateDebugText("hittime", "HITTIME: " + hitTime);
			}
			else
			{
				hitNormal = Vector3.zero;
				hasHit = false;
				climbDir = GetPlayerUpVector();
				jumpDir = GetPlayerUpVector();
			}
			sprintFOV = SettingsManager.settings.playerFOV + 15f * speedMult;
			if (!camLocked)
			{
				MouseLook();
			}
			Hand[] array = hands;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].LateUpdate();
			}
			Actions();
			if (!dead && healTimer <= 0f)
			{
				health = Mathf.Clamp(health + Time.deltaTime * healingRate, 0f, maxHealth);
			}
			if (!dead)
			{
				if (hasOxygen)
				{
					curBreathAmount = Mathf.Clamp(curBreathAmount + Time.deltaTime * 5f, 0f, breathMax);
				}
				else
				{
					curBreathAmount = Mathf.Clamp(curBreathAmount - Time.deltaTime, 0f, breathMax);
					if (curBreathAmount <= 0f)
					{
						if (breathHurtTimer > 0f)
						{
							breathHurtTimer -= Time.deltaTime;
						}
						else
						{
							breathHurtTimer = 1f;
							Damage(Damageable.DamageInfo.CreateDamageInfo(0.25f, "drowned"));
						}
					}
				}
			}
			DebugMenu.UpdateDebugText("health", "<color=red>Health: " + health + " / " + maxHealth);
			DebugMenu.UpdateDebugText("breath", "<color=blue>Breath: " + curBreathAmount + " / " + breathMax);
			healTimer -= Time.deltaTime;
			if (tick <= 0f)
			{
				tick = 0.15f;
				SlowTick();
			}
			tick -= Time.deltaTime;
			ApplyBuffEffects();
			PoisonCheck();
			if (grabAnywhereHit[0] != null)
			{
				grabAnywhereFakeHandholds[0].transform.position = grabAnywhereHit[0].TransformPoint(grabAnywherePosition[0]);
				grabAnywhereFakeHandholds[0].transform.rotation = quaternion.identity;
			}
			if (grabAnywhereHit[1] != null)
			{
				grabAnywhereFakeHandholds[1].transform.position = grabAnywhereHit[1].TransformPoint(grabAnywherePosition[1]);
				grabAnywhereFakeHandholds[1].transform.rotation = quaternion.identity;
			}
			lastVel = cCon.velocity;
			FallingDamage();
			timeSinceLastHit += Time.deltaTime;
			DebugMenu.UpdateDebugText("lasthittime", "<color=red>Time Since Last Hit: " + timeSinceLastHit);
		}
		SoftParentWait();
		for (int num3 = perks.Count - 1; num3 >= 0; num3--)
		{
			perks[num3].Update();
		}
	}

	private void SlowTick()
	{
		curFootstep = GetFootstepMaterial();
		AchievementCheck();
		if (grapplers != null && grapplers.Count > 0)
		{
			for (int num = grapplers.Count - 1; num >= 0; num--)
			{
			}
		}
	}

	private void SoftParentWait()
	{
		StartCoroutine(WaitFunc());
		IEnumerator WaitFunc()
		{
			if (softParent.IsParented())
			{
				DebugMenu.UpdateDebugText("trueChangeVector", "True Change Vector : " + (base.transform.position - lastPlayerPosition));
				base.transform.position += softParent.GetPositionDeltaWorldDifference();
				lastFixedPlayerPosition += softParent.GetPositionDeltaWorldDifference();
				currentFixedCameraPosition += softParent.GetPositionDeltaWorldDifference();
				previousFixedCameraPosition += softParent.GetPositionDeltaWorldDifference();
				softParent.UpdatePositionInfo();
				softParent.UpdateRotationInfo();
			}
			lastPlayerPosition = base.transform.position;
			yield return new WaitForEndOfFrame();
		}
	}

	private void WindSound()
	{
		if (!dead)
		{
			windAudio.volume = Mathf.Lerp(windAudio.volume, Mathf.Max((0f - cCon.velocity.y - 2f) * windAudioVelocityMultiplier, 0f), Time.fixedDeltaTime * 5f);
			if (cCon.velocity.y < -2f && !fallingAudio)
			{
				fallingAudio = true;
				windAudio.Play();
			}
			else if (fallingAudio && isGrounded && !isSliding)
			{
				fallingAudio = false;
			}
		}
	}

	private void AimCircle(InteractHit hit, Hand curhand)
	{
		if (curhand.GetHandItem() != null && curhand.inventoryHand.currentItem.handItemAsset.ShowAimCircle())
		{
			RaycastHit aimCircleHit = curhand.inventoryHand.currentItem.handItemAsset.GetAimCircleHit();
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.SphereOutline(aimCircleHit.point, 0.3f);
			}
			aimCircle.gameObject.SetActive(value: true);
			aimCircle.transform.position = aimCircleHit.point + aimCircleHit.normal * 0.01f;
			aimCircle.transform.rotation = Quaternion.LookRotation(aimCircleHit.normal);
		}
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		if (godmode)
		{
			return false;
		}
		info.type = info.type.ToLower();
		lastHitSource = info.type;
		bool flag = !info.HasTag("NoEffects");
		Vector2 direction = Vector2.zero;
		if (info.position != Vector3.zero)
		{
			Vector3 position = info.position;
			if (info.sourceEntity != null)
			{
				position = info.sourceEntity.transform.position;
			}
			direction = cam.transform.InverseTransformVector(Vector3.ProjectOnPlane((position - cam.transform.position).normalized, cam.transform.forward));
			Debug.Log("Damage Direction: " + direction);
		}
		if (flag)
		{
			if (info.isLight || info.HasTag("LightAttack"))
			{
				CL_CameraControl.Shake(0.02f);
				gMan.uiMan.Hurt(direction, 0.45f);
				info.isLight = true;
			}
			else
			{
				CL_CameraControl.Shake(0.1f * info.intensity);
				gMan.uiMan.Hurt(direction);
			}
		}
		timeSinceLastHit = 0f;
		info = ProcessDamageInfo(info);
		info.amount /= 1f + curBuffs.GetBuff("damageResist");
		info.amount *= 1f + curBuffs.GetBuff("damageMult");
		if (info.amount > 0f && flag)
		{
			healTimer = healDelay;
		}
		if ((info.type == "teeth" || info.type == "phage") && health - info.amount <= 0f)
		{
			return true;
		}
		if (info.type.ToLower() == "gasbag" || info.type.ToLower() == "turret" || info.type == "steam")
		{
			DropHang(0.1f, 1f, cooldownOnlyOnHangingHands: false, "drop", canResist: true);
		}
		if (info.type == "rebarexplosion")
		{
			CL_AchievementManager.SetAchievementValue("ACH_ROCKETJUMP", b: true);
		}
		if (info.type == "steam" || info.type == "heat")
		{
			if (flag)
			{
				clipHandler.GetGroup("player").GetSet("hurt-heat").Play(1f, audioChannels[1]);
			}
			Hand[] array = hands;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].ShakeHand(0.05f);
			}
		}
		else if (info.type == "falling")
		{
			if (flag)
			{
				clipHandler.GetGroup("player").GetSet("hurt-falling").Play(1f, audioChannels[1]);
			}
		}
		else if (!(info.type == "poison") && !info.isLight && flag)
		{
			clipHandler.GetGroup("player").GetSet("hurt").Play(1f, audioChannels[1]);
		}
		if (info.HasTag("nonlethal"))
		{
			return false;
		}
		if (info.HasTag("dontkill"))
		{
			info.amount = Mathf.Min(info.amount, health - 0.1f);
		}
		bool num = base.Damage(info);
		if (info.HasTag("fall-hand-0"))
		{
			hands[0].DamageGripStrength(3f);
			SplatterScreenBlood(2);
		}
		if (info.HasTag("fall-hand-1"))
		{
			hands[1].DamageGripStrength(3f);
			SplatterScreenBlood(2);
		}
		if (info.HasTag("fall-land"))
		{
			SplatterScreenBlood(2);
		}
		if (num)
		{
			cCon.enabled = false;
			return true;
		}
		return false;
	}

	public override void Heal(float amount)
	{
		base.Heal(amount);
	}

	public void Revive()
	{
		dead = false;
		windAudio.Play();
		cCon.enabled = true;
		inventoryCam.gameObject.SetActive(value: true);
		vel = Vector3.zero;
		health = maxHealth;
		grappled = false;
		grapplers.Clear();
		gravityMult = 1f;
		falling = false;
		SetSwimming(swim: false);
		isUnderwater = false;
		curBreathAmount = breathMax;
		hasOxygen = true;
		speedMult = 1f;
		cutsceneMode = false;
		DropHang();
		UnLock();
		inventory.RescanInventory();
	}

	public override void Kill(string type = "", Damageable.DamageInfo damageInfo = null)
	{
		if (!dead && !gMan.IsReviving() && !godmode)
		{
			dead = true;
			type = type.ToLower();
			if (OS_Manager.activeComputer != null)
			{
				OS_Manager.activeComputer.Deactivate();
			}
			Debug.Log("The Player has died.");
			StashItemsInHand(force: true);
			if (_OnKill != null)
			{
				_OnKill();
			}
			if (type == "deathfloor" && timeSinceLastHit < 3f)
			{
				Debug.Log(lastHitSource);
			}
			else
			{
				lastHitSource = type;
			}
			windAudio.Stop();
			cCon.enabled = false;
			inventoryCam.gameObject.SetActive(value: false);
			vel = Vector3.zero;
			KillAchievements(lastHitSource);
			SplatterScreenBlood(6);
			base.Kill(type, damageInfo);
			DropHang();
			gMan.Die(type);
		}
	}

	public void KillEffects(string type)
	{
		if (type == "falling")
		{
			clipHandler.GetGroup("player").GetSet("death-splatter").Play(1f);
		}
		clipHandler.GetGroup("player").GetSet("death").Play(1f);
		dead = true;
	}

	private void PoisonCheck()
	{
		float buff = curBuffs.GetBuff("poisoned");
		if (!(buff > 0f))
		{
			return;
		}
		float num = 5f + curBuffs.GetBuff("poisonTimer");
		float buff2 = curBuffs.GetBuff("poisonDamage");
		float buff3 = curBuffs.GetBuff("poisonStaminaDamage");
		bool flag = curBuffs.GetBuff("poisonDropHands") > UnityEngine.Random.value;
		poisonedHurtTime -= Time.deltaTime;
		if (!(poisonedHurtTime <= 0f))
		{
			return;
		}
		poisonedHurtTime = num;
		if (buff2 > 0f)
		{
			Damage(Damageable.DamageInfo.CreateDamageInfo(buff, "poison"));
		}
		if (buff3 > 0f)
		{
			DamageGripStrength(buff3);
		}
		if (flag)
		{
			if (IsHanging())
			{
				camRoot.ShakeCamera(0.08f);
			}
			DropHang();
		}
		camRoot.ShakeCamera(0.05f);
		clipHandler.GetGroup("player").GetSet("cough").Play(1f, audioChannels[1]);
	}

	private void FallingDamage()
	{
		if (correctedVelocity.y < -3f && !dead && !gMan.IsReviving() && !IsHanging() && !isSwimming && !noclip)
		{
			if (!falling)
			{
				fallStartHeight = gMan.GetPlayerCorrectedHeight();
				falling = true;
			}
			float num = (curFallDistance = Mathf.Max(fallStartHeight - gMan.GetPlayerCorrectedHeight(), 0f));
			DebugMenu.UpdateDebugText("falldistance", "Fall Distance: " + num);
			if (num > GetCurrentMaxFallDistance() && !noclip)
			{
				if (fallHurtTime > 0f)
				{
					fallHurtTime -= Time.deltaTime;
				}
				else
				{
					fallHurtTime = 1f;
					Damageable.DamageInfo info = Damageable.DamageInfo.CreateDamageInfo(0.1f, "falling");
					Damage(info);
				}
				camRoot.ShakeCamera(0.1f * Time.deltaTime);
				if (num > GetCurrentMaxFallDistance() * 4f && !dead)
				{
					Kill("falling");
				}
			}
			else
			{
				fallHurtTime = 0f;
			}
			if (Mathf.Abs(gMan.GetPlayerCorrectedHeight() - fallStartHeight) > 75f)
			{
				CL_AchievementManager.SetAchievementValue("ACH_LONGFALL", b: true);
			}
			return;
		}
		if (falling && !noclip)
		{
			float num2 = Mathf.Max(fallStartHeight - gMan.GetPlayerCorrectedHeight(), 0f);
			float num3 = Mathf.Ceil((num2 - (GetCurrentMaxFallDistance() + 10f)) / 15f) + 1f;
			if (num2 > GetCurrentMaxFallDistance() && ignoreFallDamageTime <= 0f)
			{
				List<string> list = new List<string>();
				if (IsHanging())
				{
					list.Add("fall-grab");
					Hand[] array = hands;
					foreach (Hand hand in array)
					{
						if (hand.IsHanging())
						{
							list.Add("fall-hand-" + hand.id);
						}
					}
				}
				else if (cCon.isGrounded)
				{
					list.Add("fall-land");
				}
				else
				{
					num3 /= 2f;
				}
				Damage(Damageable.DamageInfo.CreateDamageInfo(num3, "falling", list));
			}
			ignoreFallDamageTime = 0f;
		}
		DebugMenu.UpdateDebugText("falldistance", "Fall Distance: 0");
		falling = false;
		curFallDistance = 0f;
	}

	public void AddIgnoreFallDamageTime(float f)
	{
		ignoreFallDamageTime = Mathf.Max(ignoreFallDamageTime, f);
	}

	public void ResetFallingHeight()
	{
		falling = false;
		fallStartHeight = base.transform.position.y;
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		hitNormal = hit.normal;
		lastHitNormal = hit.normal;
		hasHit = true;
		lastHitSurfaceTime = Time.time;
		cConHit = hit;
		hitTime = 0.1f;
		float num = Vector3.Angle(GetPlayerUpVector(), hitNormal);
		if (Vector3.Dot(vel.normalized, hitNormal) <= 0f && num > slopeLimit)
		{
			Vector3 vector = Vector3.ProjectOnPlane(vel, hitNormal);
			vel = vector;
			verticalSlide = true;
		}
	}

	private void OnFireTick()
	{
		if (UnityEngine.Random.value > 0.5f)
		{
			DropHang();
		}
	}

	public static ENT_Player GetPlayer()
	{
		if (playerObject == null)
		{
			GameObject gameObject = GameObject.Find("ENT_Player");
			if (gameObject == null)
			{
				return null;
			}
			playerObject = gameObject.GetComponent<ENT_Player>();
		}
		return playerObject;
	}

	public static Inventory GetInventory()
	{
		if (playerObject == null)
		{
			GetPlayer();
		}
		if (playerObject.inventory == null)
		{
			playerObject.inventory = playerObject.gameObject.GetComponent<Inventory>();
			playerObject.inventory.Initialize(playerObject);
			Debug.Log("Initializing Inventory");
			return playerObject.inventory;
		}
		return playerObject.inventory;
	}

	public Vector3 GetCameraTargetPosition()
	{
		return cameraPosition;
	}

	public Quaternion GetCameraTargetRotation()
	{
		return cameraRotation;
	}

	public float GetCurrentFOV()
	{
		return curFOV;
	}

	private bool CanUncrouch()
	{
		Vector3 vector = base.transform.position + cCon.center + GetPlayerUpVector() * (crouchHeight / 2f);
		Vector3 end = vector + GetPlayerUpVector() * (standingHeight - crouchHeight);
		float radius = cCon.radius * 0.9f;
		bool flag = Physics.CheckCapsule(vector, end, radius, jumpMask);
		if (gMan.lockPlayer)
		{
			return false;
		}
		return !flag;
	}

	private IEnumerator ChangeHeight(float targetHeight)
	{
		float elapsedTime = 0f;
		float currentHeight = cCon.height;
		while (elapsedTime < crouchTransitionDuration)
		{
			elapsedTime += Time.deltaTime;
			float t = elapsedTime / crouchTransitionDuration;
			float num = Mathf.Lerp(currentHeight, targetHeight, t);
			_ = cCon.height;
			cCon.height = num;
			cCon.center = GetPlayerUpVector() * (num - standingHeight) * 0.5f;
			_ = targetHeight / standingHeight;
			mainCamTarget.localPosition = Vector3.Lerp(mainCamTarget.localPosition, new Vector3(0f, 0.45f + (num - standingHeight), 0f), t);
			yield return null;
		}
	}

	public Vector3 GetControllerPosition()
	{
		return base.transform.TransformPoint(cCon.center);
	}

	public void SetGravityMult(float g)
	{
		gravityMult = g;
	}

	public void SetTempFrictionMultiplier(float t)
	{
		tempFrictionMult *= t;
	}

	public void SetTempGravityMult(float g)
	{
		tempGravityMult *= g;
	}

	public static bool IsNullOrDestroyed(object obj)
	{
		return obj?.Equals(null) ?? true;
	}

	public bool IsLocked()
	{
		if (!camLocked)
		{
			return isFrozen();
		}
		return true;
	}

	public bool IsMoveLocked()
	{
		if (!isFrozen() && !moveLocked && !gMan.lockPlayer && !gMan.IsReviving())
		{
			return moveToLocked;
		}
		return true;
	}

	public bool IsInputLocked()
	{
		if (!isFrozen())
		{
			return gMan.lockPlayerInput;
		}
		return true;
	}

	public bool isFrozen()
	{
		if (!paused && !gMan.freecam && !dead)
		{
			return gMan.isPaused;
		}
		return true;
	}

	public bool IsInventoryLocked()
	{
		return invLocked;
	}

	public void FOVShock(float s, bool slow = false)
	{
		if (slow)
		{
			if (s >= 0f)
			{
				slowFOVAdjust = Mathf.Max(slowFOVAdjust, s);
			}
			else
			{
				slowFOVAdjust = Mathf.Min(slowFOVAdjust, s);
			}
		}
		else
		{
			smoothedFOV += s;
		}
	}

	public void SetFOVShock(float s, bool slow = false)
	{
		if (slow)
		{
			if (s >= 0f)
			{
				slowFOVAdjust = Mathf.Max(slowFOVAdjust, s);
			}
			else
			{
				slowFOVAdjust = Mathf.Min(slowFOVAdjust, s);
			}
		}
		else
		{
			smoothedFOV = s;
		}
	}

	public void LockCamera()
	{
		camLocked = true;
	}

	public void UnlockCamera()
	{
		camLocked = false;
		mouseInteract = true;
		vel = Vector3.zero;
	}

	public void Lock()
	{
		mouseInteract = false;
		camLocked = true;
		moveLocked = true;
		Cursor.lockState = CursorLockMode.Locked;
		invLocked = true;
		vel = Vector3.zero;
	}

	public void UnLock()
	{
		mouseInteract = true;
		camLocked = false;
		moveLocked = false;
		invLocked = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void LockMovementInput()
	{
		moveLocked = true;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void LockInteraction()
	{
		moveLocked = true;
		mouseInteract = true;
		hideHands = true;
		invLocked = true;
	}

	public void UnlockInteraction()
	{
		moveLocked = false;
		mouseInteract = false;
		hideHands = false;
		invLocked = false;
	}

	public bool IsInteractionLocked()
	{
		if (!hideHands)
		{
			return invLocked;
		}
		return true;
	}

	internal override void ClampVelocityToAxis(Vector3 up)
	{
		vel = Vector3.ProjectOnPlane(vel, up);
		isGrounded = false;
		lastVel = vel;
		cCon.Move(-cCon.velocity * Time.fixedDeltaTime);
	}

	public override void SetDirectionalForce(Vector3 v)
	{
		ClampVelocityToAxis(v);
		canJumpThisFrame = false;
		forceAirbornTime = 0.05f;
		falling = false;
		if (Vector3.Dot(GetPlayerUpVector(), v) > 0f)
		{
			ignoreFallDamageTime = 5f;
		}
		AddForce(v);
	}

	public void ReflectPlayerVelocity(Vector3 normal)
	{
		vel = Vector3.Reflect(vel, normal);
		isGrounded = false;
		lastVel = vel;
		cCon.Move(-cCon.velocity * Time.fixedDeltaTime);
		canJumpThisFrame = false;
		forceAirbornTime = 0.05f;
	}

	public void ScaleVelocityMagnitude(float magnitude = 1f)
	{
		vel *= magnitude;
		lastVel = vel;
		cCon.Move(-cCon.velocity * Time.fixedDeltaTime);
	}

	public void ScaleVelocity(Vector3 scalar)
	{
		vel = Vector3.Scale(vel, scalar);
		lastVel = Vector3.Scale(vel, scalar);
		cCon.Move(-cCon.velocity * Time.fixedDeltaTime);
	}

	public Vector3 GetVelocity()
	{
		return vel;
	}

	public override void AddForce(Vector3 v, string source = "")
	{
		if (!IsMoveLocked())
		{
			switch (source)
			{
			case "hazard":
			case "denizen":
			case "projectile":
				v /= 1f + curBuffs.GetBuff("knockbackResist");
				break;
			}
			v /= 10f;
			vel += v;
			if ((double)v.y > 0.05)
			{
				isGrounded = false;
				forceAirbornTime = 0.05f;
			}
		}
	}

	public override void AddForce(Vector3 v, float maxVel, string source = "", float maxVelScale = 0f)
	{
		switch (source)
		{
		case "hazard":
		case "denizen":
		case "projectile":
			v /= 1f + curBuffs.GetBuff("knockbackResist");
			break;
		}
		v /= 10f;
		float magnitude = Vector3.Project(vel + v, v).magnitude;
		float num = 1f;
		if (!(magnitude < maxVel))
		{
			Vector3.Dot(vel.normalized, v.normalized);
			_ = 0f;
		}
		if (magnitude > maxVel)
		{
			num = maxVelScale;
		}
		Vector3 vector = vel + v * num;
		vel = vector;
		if (cCon.enabled)
		{
			cCon.Move(v * num);
		}
		if (v.y > 0.05f)
		{
			isGrounded = false;
			forceAirbornTime = 0.05f;
		}
		if (v.y > 0f && vel.y > -4f)
		{
			AddIgnoreFallDamageTime(1f);
		}
	}

	public override void AddForceAtPosition(Vector3 v, Vector3 p, string source = "")
	{
		AddForce(v);
	}

	public void AddRotationVelocity(Vector3 v)
	{
		cameraRotationVelocity += v;
	}

	public void AddQuickRotationVelocity(Vector3 v)
	{
		cameraQuickRotationVelocity += v;
	}

	public Vector3 GetCurrentPlayerRotation()
	{
		Vector3 eulerAngles = camTransform.localRotation.eulerAngles;
		eulerAngles.x = camY;
		eulerAngles.y = base.transform.rotation.eulerAngles.y;
		return eulerAngles;
	}

	public void SetPlayerRotation(Vector3 eulerRot)
	{
		base.transform.rotation = Quaternion.Euler(0f, eulerRot.y, 0f);
		camTransform.localRotation = Quaternion.Euler(eulerRot.x, 0f, eulerRot.z);
		camY = eulerRot.x;
	}

	public void RotatePlayerTowardsRotation(Vector3 target, float speed)
	{
		Vector3 vector = target - GetCurrentPlayerRotation();
		AddRotationVelocity(vector * speed);
	}

	public override void TonguePull(Vector3 v)
	{
		base.TonguePull(v);
		grappled = true;
		Vector3 vector = new Vector3(InputManager.GetVector("Move").vector.x, InputManager.GetVector("Move").vector.y);
		v += base.transform.forward * vector.y * Time.deltaTime * 0.01f;
		v += base.transform.right * vector.x * Time.deltaTime * 0.01f;
		if ((GetAverageGrappleInfo().forceLeaveGrounded || v.y > 0.0003f) && cCon.isGrounded)
		{
			v += GetPlayerUpVector() * 0.01f;
			cCon.Move(v);
		}
		else if (cCon.isGrounded)
		{
			v.y = 0f;
			v.x *= 1.5f;
			v.z *= 1.5f;
		}
		if (v.y > 0f)
		{
			v.y *= 3f;
		}
		vel += v;
	}

	public void ResetCameraInterpolation()
	{
		previousFixedCameraPosition = mainCamTarget.position;
		currentFixedCameraPosition = mainCamTarget.position;
		camRoot.transform.position = currentFixedCameraPosition;
		lastFixedPlayerPosition = base.transform.position;
	}

	public override void Teleport(Vector3 pos)
	{
		ClearGrapple();
		base.Teleport(pos);
		if (softParent != null)
		{
			softParent.Unparent();
		}
		AddIgnoreFallDamageTime(2f);
		_OnTeleport?.Invoke();
	}

	public override void Teleport(Vector3 pos, Quaternion rot, bool keepVelocity = false)
	{
		ClearGrapple();
		DropHang();
		if (cCon.enabled)
		{
			cCon.enabled = false;
			falling = false;
			base.Teleport(pos, rot);
			fallStartHeight = pos.y;
			cCon.enabled = true;
		}
		else
		{
			base.Teleport(pos, rot);
			fallStartHeight = pos.y;
			falling = false;
		}
		if (!keepVelocity)
		{
			vel = Vector3.zero;
			lastVel = Vector3.zero;
			lastFixedPlayerPosition = base.transform.position;
			lastPlayerPosition = base.transform.position;
		}
		previousFixedCameraPosition = mainCamTarget.position;
		currentFixedCameraPosition = mainCamTarget.position;
		camRoot.transform.position = currentFixedCameraPosition;
		lastFixedPlayerPosition = base.transform.position;
		if (softParent != null)
		{
			softParent.Unparent();
		}
		AddIgnoreFallDamageTime(2f);
	}

	public void MovePlayerToPosition(Vector3 pos)
	{
		base.transform.position = pos;
		previousFixedCameraPosition = mainCamTarget.position;
		currentFixedCameraPosition = mainCamTarget.position;
		lastFixedPlayerPosition = base.transform.position;
	}

	public void MoveTo(Vector3 targetPos, float moveTime, float velMult = 10f)
	{
		float curTime;
		Vector3 startPos;
		if (Time.fixedTime != lastFrame)
		{
			lastFrame = Time.fixedTime;
			moveToLocked = true;
			if (currentMoveCoroutine != null)
			{
				StopCoroutine(currentMoveCoroutine);
			}
			curTime = moveTime;
			startPos = base.transform.position;
			lastMoveToTarget = targetPos;
			currentMoveCoroutine = StartCoroutine(MovePlayerTo());
		}
		IEnumerator MovePlayerTo()
		{
			while (curTime > 0f)
			{
				Vector3 vector = targetPos - base.transform.position;
				base.transform.position = Vector3.Lerp(startPos, targetPos, 1f - curTime / moveTime);
				curTime -= Time.deltaTime;
				vel = vector * Time.fixedDeltaTime * velMult;
				if (curTime > 0f)
				{
					yield return null;
				}
			}
			moveToLocked = false;
		}
	}

	public bool IsGrounded(bool includeCoyoteTime = false)
	{
		if (includeCoyoteTime)
		{
			if (!(timeSinceGrounded < coyoteTime))
			{
				return isGrounded;
			}
			return true;
		}
		return isGrounded;
	}

	public float GetTimeSinceGrounded()
	{
		return timeSinceGrounded;
	}

	public bool IsFlying()
	{
		if (!fly)
		{
			return curBuffs.GetBuff("flight") > 0f;
		}
		return true;
	}

	public void SetGravity(bool b)
	{
		hasGravity = b;
	}

	public void FreezeInputForTime(float f)
	{
		StartCoroutine(FreezeCoroutine(f));
		IEnumerator FreezeCoroutine(float seconds)
		{
			LockMovementInput();
			yield return new WaitForSeconds(seconds);
			UnLock();
		}
	}

	public void FreezeInputForFrame()
	{
		StartCoroutine(FreezeCoroutine());
		static IEnumerator FreezeCoroutine()
		{
			InputManager.DeactivateMap(0);
			yield return null;
			InputManager.ActivateMap(0);
		}
	}

	public float GetCurrentFallDistance()
	{
		return curFallDistance;
	}

	public string GetLastHitSource()
	{
		return lastHitSource;
	}

	public static Vector3 MostYFacingPerpendicular(Vector3 inputVector)
	{
		inputVector.Normalize();
		return Vector3.ProjectOnPlane(GetPlayer().GetPlayerUpVector(), inputVector).normalized;
	}

	public bool CanStashItemsInHand()
	{
		Hand[] array = hands;
		foreach (Hand hand in array)
		{
			if (hand.GetHandItem() != null && !hand.GetHandItem().CanDrop())
			{
				return false;
			}
		}
		return true;
	}

	internal void StashItemsInHand(bool force = false)
	{
		inventory.DropItemFromHand(inventory.inventoryCenterLocator.position, 0, addtoInventory: true, force);
		inventory.DropItemFromHand(inventory.inventoryCenterLocator.position, 1, addtoInventory: true, force);
	}

	private bool IsSprintHeld()
	{
		if (((InputManager.GetButton("Sprint").Pressed && !SettingsManager.settings.alwaysSprint) || (SettingsManager.settings.alwaysSprint && !InputManager.GetButton("Sprint").Pressed)) && inputAxis.magnitude > 0.8f)
		{
			return !crouching;
		}
		return false;
	}

	private bool IsCrouchHeld()
	{
		return InputManager.GetButton("Crouch").Pressed;
	}

	private bool IsFocusModeActive()
	{
		if (!focusToggled)
		{
			if (!SettingsManager.settings.toggleFocus)
			{
				return InputManager.GetButton("Focus").Pressed;
			}
			return false;
		}
		return true;
	}

	internal void SetCrouched(bool v)
	{
		crouching = true;
		cCon.height = crouchHeight;
	}

	public bool IsCrouching()
	{
		return crouching;
	}

	public bool IsSprinting()
	{
		return sprinting;
	}

	public bool IsInFullSprint()
	{
		if (sprinting && timeSinceSprinting > 0.1f)
		{
			return timeSinceGrounded < 0.1f;
		}
		return false;
	}

	public override void OffsetEntity(float amount)
	{
		base.OffsetEntity(amount);
		Hand[] array = hands;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].OffsetLastHoldPosition(Vector3.up * amount);
		}
	}

	public bool IsHanging()
	{
		bool result = false;
		Hand[] array = hands;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].interactState == InteractType.hanging)
			{
				result = true;
			}
		}
		return result;
	}

	public void DropHang(float grabCooldown = 0.1f, float gripStrengthLoss = 1f, bool cooldownOnlyOnHangingHands = false, string stopInteractType = "drop", bool canResist = false)
	{
		if (canResist && UnityEngine.Random.value < curBuffs.GetBuff("gripResist"))
		{
			return;
		}
		Hand[] array = hands;
		foreach (Hand hand in array)
		{
			if (hand.interactState == InteractType.hanging)
			{
				StopInteraction(hand.id, stopInteractType);
				hand.gripStrength -= gripStrengthLoss / (curBuffs.GetBuff("addGripStrength") + 1f + GetBuffOnHand("addGripStrength", hand.id));
				if (cooldownOnlyOnHangingHands && hand.grabWait < grabCooldown)
				{
					hand.grabWait = grabCooldown;
				}
			}
			if (!cooldownOnlyOnHangingHands && hand.grabWait < grabCooldown)
			{
				hand.grabWait = grabCooldown;
			}
			hand.uiInteract.gameObject.SetActive(value: false);
		}
	}

	public void DropHangWithThreshold(float staminaThreshold, float gripStrengthLoss = 1f, bool cooldownOnlyOnHangingHands = false, string stopInteractType = "drop", bool canResist = false)
	{
		if (canResist && UnityEngine.Random.value < curBuffs.GetBuff("gripResist"))
		{
			return;
		}
		Hand[] array = hands;
		foreach (Hand hand in array)
		{
			if (hand.interactState == InteractType.hanging && hand.gripStrength < staminaThreshold)
			{
				StopInteraction(hand.id, stopInteractType);
				hand.gripStrength -= gripStrengthLoss / (curBuffs.GetBuff("addGripStrength") + 1f + GetBuffOnHand("addGripStrength", hand.id));
				if (cooldownOnlyOnHangingHands && hand.grabWait < 0.1f)
				{
					hand.grabWait = 0.1f;
				}
				hand.uiInteract.gameObject.SetActive(value: false);
				if (!cooldownOnlyOnHangingHands && hand.grabWait < 0.1f)
				{
					hand.grabWait = 0.1f;
				}
			}
		}
	}

	internal void DropEverything(bool destroyItems = true, float dropTime = 5f)
	{
		DropHang(dropTime);
		Hand[] array = hands;
		foreach (Hand hand in array)
		{
			if (destroyItems)
			{
				hand.DestroyItem();
			}
			else
			{
				hand.DropItem();
			}
			hand.uiInteract.gameObject.SetActive(value: false);
		}
	}

	public override float GetVisibility()
	{
		float num = base.GetVisibility();
		if (crouching)
		{
			num = ((!IsGrounded()) ? (num * 0.5f) : (num * 0.25f));
		}
		return num;
	}

	public static bool CanHoldItems()
	{
		return !OS_Manager.IsAnyComputerInUse();
	}

	public void SetCutsceneMode(bool b)
	{
		cutsceneMode = b;
	}

	public bool IsSwimming()
	{
		return isSwimming;
	}

	public bool IsCameraUnderwater()
	{
		return isUnderwater;
	}

	public bool HasPlayerStateInFlagList(List<string> stateFlagList, int hand = -1)
	{
		foreach (string stateFlag in stateFlagList)
		{
			switch (stateFlag)
			{
			case "isSprinting":
				if (IsSprinting())
				{
					return true;
				}
				break;
			case "isFullSprinting":
				if (IsInFullSprint())
				{
					return true;
				}
				break;
			case "isCrouching":
				if (IsCrouching())
				{
					return true;
				}
				break;
			case "isWalking":
				if (IsGrounded() && !IsSprinting() && curVel.magnitude > 0.1f)
				{
					return true;
				}
				break;
			case "isJumping":
				if (Time.time - lastJumpTime < 0.5f)
				{
					return true;
				}
				break;
			case "isAirborn":
				if (!IsGrounded())
				{
					return true;
				}
				break;
			case "isGrounded":
				if (IsGrounded())
				{
					return true;
				}
				break;
			case "isHanging":
				if (IsHanging())
				{
					return true;
				}
				break;
			case "isClimbingAgainstSurface":
				if (IsHanging() && Time.time - lastHitSurfaceTime < 0.2f && Vector3.Angle(-cam.transform.forward, hitNormal) < 90f && moveAxis.y > 0.1f)
				{
					return true;
				}
				break;
			case "isFalling":
				if (correctedVelocity.y < 0.5f && !dead && !gMan.IsReviving() && !IsHanging() && !isSwimming && !noclip)
				{
					return true;
				}
				break;
			case "isLongFalling":
				if (falling && curFallDistance > GetCurrentMaxFallDistance() / 2f)
				{
					return true;
				}
				break;
			case "isUnderHalfHealth":
				if (health < maxHealth / 2f)
				{
					return true;
				}
				break;
			case "isUnderQuarterHealth":
				if (health < maxHealth / 4f)
				{
					return true;
				}
				break;
			case "isAtFullHealth":
				if (health >= maxHealth)
				{
					return true;
				}
				break;
			case "isUnderHalfStamina":
				if (hand == -1 && GetLowestGripStrength() < GetCurrentGripStrengthTimer() / 2f)
				{
					return true;
				}
				if (hands[hand].GetGripStrengthPercent() < 0.5f)
				{
					return true;
				}
				break;
			case "isUnderQuarterStamina":
				if (hand == -1 && GetLowestGripStrength() < GetCurrentGripStrengthTimer() / 4f)
				{
					return true;
				}
				if (hands[hand].GetGripStrengthPercent() < 0.25f)
				{
					return true;
				}
				break;
			case "isAtFullStamina":
				if (hand == -1 && GetLowestGripStrength() >= GetCurrentGripStrengthTimer())
				{
					return true;
				}
				if (hands[hand].GetGripStrengthPercent() >= 1f)
				{
					return true;
				}
				break;
			case "isRoided":
				if (curBuffs.GetBuff("roided") > 0f)
				{
					return true;
				}
				break;
			case "isPilled":
				if (curBuffs.GetBuff("pilled") > 0f)
				{
					return true;
				}
				break;
			case "isGooped":
				if (curBuffs.GetBuff("gooped") > 0f)
				{
					return true;
				}
				break;
			}
		}
		return false;
	}

	internal int GetTemporaryExtraJumpsRemaining()
	{
		return temporaryExtraJumpsRemaining;
	}

	public void SplatterScreenBlood(int amount, Color color)
	{
		if (!SettingsManager.settings.hideSplatterOverlay)
		{
			ParticleSystem.MainModule main = bloodEffect.main;
			main.startColor = color;
			bloodEffect.Emit(amount);
		}
	}

	public void SplatterScreenBlood(int amount)
	{
		SplatterScreenBlood(amount, new Color(0.5f, 0f, 0f, 0.9f));
	}

	public void SplatterScreenBlood(int amount, List<string> tags)
	{
		if (tags.Contains("Grub"))
		{
			GetPlayer().SplatterScreenBlood(3, new Color(0.88f, 0.94f, 0.67f, 0.9f));
		}
		else if (tags.Contains("Mechanical"))
		{
			GetPlayer().SplatterScreenBlood(amount, DarkMachineCrayons.ColorFromHex(993079807u));
		}
		else
		{
			SplatterScreenBlood(amount);
		}
	}

	private void OnDestroy()
	{
		if (perks != null && perks.Count != 0)
		{
			for (int num = perks.Count - 1; num >= 0; num--)
			{
				perks[num].RemoveFromPlayer();
			}
		}
	}

	public bool GetGodmode()
	{
		return godmode;
	}

	public void OnKillDenizen(Denizen d, Damageable.DamageInfo damageInfo)
	{
		if (damageInfo.HasTag("handgun"))
		{
			if (Time.time - achHandgunMultikillTimer > 2f)
			{
				achHandgunMultikillCounter = 0;
			}
			achHandgunMultikillTimer = Time.time;
			achHandgunMultikillCounter++;
			if (achHandgunMultikillCounter >= 5)
			{
				CL_AchievementManager.SetAchievementValue("ACH_HANDGUN", b: true);
			}
		}
	}

	public Vector3 GetPlayerUpVector()
	{
		return base.transform.up;
	}

	public Vector3 GetPlayerGravityVector()
	{
		return Vector3.up;
	}

	private void FootstepAudio(Vector3 moveAxis, float curSpeed)
	{
		if (!(moveAxis.magnitude > 0.5f) || !(timeSinceGrounded < 0.2f))
		{
			return;
		}
		footstepTime -= Mathf.Max(curSpeed, 1.2f) * Time.deltaTime;
		if (footstepTime <= 0f)
		{
			int num;
			for (num = UnityEngine.Random.Range(0, curFootstep.audio.Count); num == lastFootstep; num = UnityEngine.Random.Range(0, curFootstep.audio.Count))
			{
			}
			lastFootstep = num;
			AudioClip audioClip = clipHandler.GetOverrideSet("footstep", curFootstep.material.ToString())?.GetClip();
			if (audioClip == null)
			{
				audioClip = curFootstep.audio[num];
			}
			AudioManager.PlaySound(audioClip, base.transform.position, curFootstep.volume, UnityEngine.Random.Range(curFootstep.minPitch, curFootstep.maxPitch), 0f);
			AudioManager.PlayListenedSound("footstep", base.transform.position, curFootstep.volume * 5f);
			if (crouching)
			{
				footstepTime = footstepCrouchSpeed;
			}
			else if (sprinting)
			{
				footstepTime = footstepSprintSpeed;
			}
			else
			{
				footstepTime = footstepSpeed;
			}
		}
	}

	private Footsteps GetFootstepMaterial()
	{
		Footsteps result = footsteps[0];
		if (Physics.SphereCast(base.transform.position, cCon.radius * 0.8f, -base.transform.up, out var hitInfo, cCon.height + 0.5f, stepMask))
		{
			Collider collider = hitInfo.collider;
			curFootstepRaycast = hitInfo;
			if (collider == null)
			{
				return result;
			}
			ObjectMaterial component = collider.GetComponent<ObjectMaterial>();
			DebugMenu.UpdateDebugText("footstepmaterial", "Footstep Material: " + footsteps[0].name);
			if (component == null)
			{
				return footsteps[0];
			}
			for (int i = 0; i < footsteps.Count; i++)
			{
				if (footsteps[i].material == component.GetMaterialType())
				{
					DebugMenu.UpdateDebugText("footstepmaterial", "Footstep Material: " + footsteps[i].name);
					return footsteps[i];
				}
			}
		}
		if (UT_SwimZone.IsPositionInAnySwimZone(base.transform.position + -base.transform.up * (cCon.height * 0.5f) * base.transform.localScale.magnitude, out var _))
		{
			for (int j = 0; j < footsteps.Count; j++)
			{
				if (footsteps[j].material == ObjectMaterial.MaterialType.water)
				{
					DebugMenu.UpdateDebugText("footstepmaterial", "Footstep Material: " + footsteps[j].name);
					return footsteps[j];
				}
			}
		}
		return result;
	}

	private void LandingAudio()
	{
		if (IsHanging() && timeSinceGrounded > 0.2f && cCon.isGrounded)
		{
			clipHandler.GetGroup("movement").GetSet("mantle").Play(1f, audioChannels[1]);
		}
		else
		{
			if (wasGrounded == cCon.isGrounded || isSliding)
			{
				return;
			}
			curFootstep = GetFootstepMaterial();
			if (cCon.isGrounded && lastVel.y < 0f - softLandCutoff && (timeSinceGrounded > 0.2f || IsHanging()) && !dead)
			{
				if (curFootstep.useLandingAudio)
				{
					clipHandler.GetGroup("movement").GetSet("land-heavy").PlaySound(curFootstep.landingAudioVolume, curFootstep.landingAudio[UnityEngine.Random.Range(0, curFootstep.landingAudio.Count)]);
					if (curFootstep.landingEffect != null)
					{
						if (!playerEffects.ContainsKey(curFootstep.landingEffect.name))
						{
							playerEffects.Add(curFootstep.landingEffect.name, UnityEngine.Object.Instantiate(curFootstep.landingEffect, curFootstepRaycast.point, Quaternion.identity, effectsRoot));
						}
						ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
						{
							position = curFootstepRaycast.point,
							applyShapeToPosition = true
						};
						playerEffects[curFootstep.landingEffect.name].Emit(emitParams, 20);
					}
				}
				else if (lastVel.y < 0f - heavyLandCutoff)
				{
					clipHandler.GetGroup("movement").GetSet("land-heavy").Play(1f, audioChannels[1]);
					CL_CameraControl.Shake(0.05f);
					ViewSway.RecieveGlobalImpulse(Vector3.down * 0.5f);
				}
				else if (lastVel.y < 0f - mediumLandCutoff)
				{
					clipHandler.GetGroup("movement").GetSet("land-medium").Play(1f, audioChannels[1]);
					CL_CameraControl.Shake(0.01f);
					ViewSway.RecieveGlobalImpulse(Vector3.down * 0.3f);
				}
				else
				{
					clipHandler.GetGroup("movement").GetSet("land-soft").Play(1f, audioChannels[1]);
					ViewSway.RecieveGlobalImpulse(Vector3.down * 0.12f);
				}
				_OnLand?.Invoke();
			}
			wasGrounded = cCon.isGrounded;
		}
	}

	public void AddGripStrength(float amount, bool onlyToGrabbingHands = false, bool food = false)
	{
		Hand[] array = hands;
		foreach (Hand hand in array)
		{
			if (!onlyToGrabbingHands || hand.interactState == InteractType.hanging)
			{
				hand.AddGripStrength(amount);
			}
		}
	}

	public void DamageGripStrength(float amount, bool onlyToGrabbingHands = false)
	{
		amount /= 1f + curBuffs.GetBuff("gripResist");
		Hand[] array = hands;
		foreach (Hand hand in array)
		{
			if (!onlyToGrabbingHands || hand.interactState == InteractType.hanging)
			{
				hand.DamageGripStrength(amount);
			}
		}
	}

	public void SetGripStrength(float amount, bool onlyToGrabbingHands = false)
	{
		Hand[] array = hands;
		foreach (Hand hand in array)
		{
			if (!onlyToGrabbingHands || hand.interactState == InteractType.hanging)
			{
				hand.gripStrength = amount;
			}
		}
	}

	public void OnEat(string type)
	{
		_OnEat?.Invoke(type);
	}

	public float GetLowestGripStrength()
	{
		float num = 999f;
		Hand[] array = hands;
		foreach (Hand hand in array)
		{
			num = Mathf.Min(num, hand.gripStrength);
		}
		return num;
	}

	public float GetLowestGripStrength(out int handID)
	{
		float num = 999f;
		handID = 0;
		Hand[] array = hands;
		foreach (Hand hand in array)
		{
			if (num < hand.gripStrength)
			{
				handID = hand.id;
			}
			num = Mathf.Min(num, hand.gripStrength);
		}
		return num;
	}

	public float GetAverageGripStrength(bool onlyHangingHands = false)
	{
		float num = 0f;
		int num2 = 0;
		Hand[] array = hands;
		foreach (Hand hand in array)
		{
			if (!onlyHangingHands || hand.interactState == InteractType.hanging)
			{
				num += hand.gripStrength;
				num2++;
			}
		}
		if (num2 == 0)
		{
			return gripStrengthTimer;
		}
		return num / (float)num2;
	}

	public void SetHandsWait(float w)
	{
		Hand[] array = hands;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetHandWait(w);
		}
	}

	public float GetCurrentGripStrengthTimer(int hand = -1)
	{
		if (hand == -1)
		{
			float num = 0f;
			Hand[] array = hands;
			foreach (Hand hand2 in array)
			{
				curBuffs.GetBuff("addStamina-hand-" + hand2.id);
				curBuffs.GetBuff("divideStamina-hand-" + hand2.id);
				num = Mathf.Max(num, gripStrengthTimer * ((1f + curBuffs.GetBuff("addStamina")) / (1f + curBuffs.GetBuff("divideStamina"))) - curBuffs.GetBuff("limitGripStrength") * gripStrengthTimer);
			}
			return num;
		}
		float buffOnHand = GetBuffOnHand("addStamina", hand);
		float buffOnHand2 = GetBuffOnHand("divideStamina", hand);
		float num2 = 1f + GetBuffOnHand("limitGripStrength", hand);
		return (gripStrengthTimer * ((1f + curBuffs.GetBuff("addStamina") + buffOnHand) / (1f + curBuffs.GetBuff("divideStamina") + buffOnHand2)) - curBuffs.GetBuff("limitGripStrength") * gripStrengthTimer) / num2;
	}

	public bool AreHandsFree()
	{
		Hand[] array = hands;
		for (int i = 0; i < array.Length; i++)
		{
			if (!array[i].IsFree())
			{
				return false;
			}
		}
		return true;
	}

	public bool HasItemInAnyHand()
	{
		Hand[] array = hands;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].inventoryHand.HasItem())
			{
				return true;
			}
		}
		return false;
	}

	public bool CanUseSprintAnimations()
	{
		Hand[] array = hands;
		foreach (Hand hand in array)
		{
			if (!hand.IsFree())
			{
				if (hand.GetHandItem() != null && hand.GetHandItem().allowSprintAnimations)
				{
					return true;
				}
				return false;
			}
		}
		return true;
	}

	private void OnGUI()
	{
		if (showDebugInfoPanel)
		{
			GUI.skin = CL_UIManager.instance.defaultSkin;
			debugWindowRect = GUILayout.Window(0, debugWindowRect, WindowFunction, "Player Info");
		}
	}

	private void WindowFunction(int windowID)
	{
		GUILayout.BeginVertical();
		debugScrollPosition = GUILayout.BeginScrollView(debugScrollPosition);
		GUILayout.Label($"Position: {GetPlayer().transform.position}");
		GUILayout.Label($"Rotation: {GetPlayer().GetCameraTargetRotation()}");
		GUILayout.Space(10f);
		GUILayout.Label("<size=18>States</size>");
		GUILayout.Label($"<color=red>Health: {GetPlayer().health} / {GetPlayer().maxHealth}</color>");
		GUILayout.Label($"<color=blue>Breath: {GetPlayer().curBreathAmount} / {GetPlayer().breathMax}</color>");
		GUILayout.Label($"Velocity: {GetVelocity()}");
		GUILayout.Label($"Velocity (Predicted): {GetTrueVelocity()}");
		GUILayout.Space(10f);
		GUILayout.Label("<size=18>Hands</size>");
		Hand[] array = hands;
		foreach (Hand hand in array)
		{
			GUILayout.Space(10f);
			GUILayout.Label($"Hand: {hand.id}");
			GUILayout.Label("----");
			GUILayout.Label($"Is Free: {hand.IsFree()}");
			GUILayout.Label($"State: {hand.interactState}");
			GUILayout.Label($"Current Interact: {hand.currentInteract}");
			GUILayout.Label($"Item: {hand.GetHandItem()}");
			GUILayout.Label($"Cooldown: {Math.Round(hand.cooldown, 2)} || GrabWait: {Math.Round(hand.grabWait, 2)}");
		}
		GUILayout.EndScrollView();
		GUILayout.EndVertical();
		GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
	}

	private void Actions()
	{
		Physics.queriesHitBackfaces = false;
		if (hands[0].interactState == InteractType.hanging && hands[1].interactState == InteractType.hanging)
		{
			gripStrengthLossRate = 0.5f;
		}
		else
		{
			gripStrengthLossRate = 1f;
		}
		aimCircle.gameObject.SetActive(value: false);
		if (!gMan.isPaused)
		{
			gMan.uiMan.crosshairController.SetCrosshairFocus(IsFocusModeActive());
			StartInteraction(0);
			StartInteraction(1);
		}
		UT_AudioClipHandler.AudioSet set = clipHandler.GetGroup("fatigue").GetSet("level");
		if (IsHanging())
		{
			set.SetVolume(Mathf.Lerp(set.GetCurrentVolume(), (1f - GetLowestGripStrength() / gripStrengthTimer - 0.5f) * 2f * set.maxVolume, CL_GameManager.GetPlayerPerceivedDeltaTime() * 3f));
		}
		else
		{
			set.SetVolume(Mathf.Lerp(set.GetCurrentVolume(), 0f, CL_GameManager.GetPlayerPerceivedDeltaTime() * 3f));
		}
	}

	public float InteractSphereRadius()
	{
		float num = Mathf.Clamp(cCon.velocity.magnitude * 0.03f, 0.15f, 0.3f);
		if (InputManager.IsGamepad())
		{
			num *= 1.5f;
		}
		return num;
	}

	private void StartInteraction(int hand)
	{
		Hand hand2 = hands[hand];
		try
		{
			hand2.BeginInteraction();
			InteractCheck(hand);
		}
		catch (Exception ex)
		{
			Debug.LogError(ex.Message);
			Debug.LogError(ex.StackTrace);
		}
		finally
		{
			hand2.EndInteraction(endAll: true);
		}
	}

	private void InteractCheck(int hand)
	{
		Hand hand2 = hands[hand];
		if (hand2.lockHand)
		{
			return;
		}
		if (camLocked)
		{
			hand2.HideInteractionSprite();
		}
		if (hand2.memoryTime > 0f)
		{
			hand2.memoryTime -= CL_GameManager.GetPlayerPerceivedDeltaTime();
		}
		if (hand2.inventoryMemoryTime > 0f)
		{
			hand2.inventoryMemoryTime -= CL_GameManager.GetPlayerPerceivedDeltaTime();
		}
		if (hand2.nohandholdsMemoryTime > 0f)
		{
			hand2.nohandholdsMemoryTime -= CL_GameManager.GetPlayerPerceivedDeltaTime();
		}
		if (!Inventory.IsShowingInventory())
		{
			hand2.inventoryMemory = null;
			hand2.inventoryMemoryTime = 0f;
		}
		if (hand2.grabWait >= 0f)
		{
			hand2.grabWait -= Time.deltaTime;
		}
		bool flag = hand2.CanInteract();
		string text = "";
		if (hand2.inventoryHand.currentItem != null)
		{
			if (hand2.inventoryHand.currentItem.interactType != Item.InteractType.none)
			{
				text += "Item Has Interactor";
				flag = true;
			}
			else
			{
				text += "Is Holding Item ";
				flag = true;
			}
		}
		if (hand2.IsLocked())
		{
			text += "Is Locked ";
			flag = false;
		}
		if ((bool)OS_Manager.activeComputer && OS_Manager.activeComputer.canControl)
		{
			text += "Is In Computer ";
			flag = false;
		}
		if (DebugMenu.visible && text == "")
		{
			text = "N/A";
		}
		bool interacting = ((!IsNullOrDestroyed(hand2.currentInteract) || hand2.grabTarget != null) ? true : false);
		string fireButton = hand2.fireButton;
		if (DebugMenu.visible)
		{
			if (hand2.grabTarget != null)
			{
				_ = "- " + hand2.grabTarget.name;
			}
			else if (hand2.currentInteract != null)
			{
				_ = "- " + hand2.currentInteract.GetGameObject().name;
			}
		}
		if (Inventory.IsShowingInventory() && hand2.GetHandItem() != null && InputManager.GetButton(fireButton).Down)
		{
			inventory.DropItemFromHand(camTransform.position + camTransform.forward, hand);
			return;
		}
		if (hand2.cooldown > 0f)
		{
			hand2.cooldown -= CL_GameManager.GetPlayerPerceivedDeltaTime();
			return;
		}
		float num = GetInteractDistance(hand);
		InteractHit interactHit = default(InteractHit);
		bool interactFound = false;
		bool flag2 = false;
		bool flag3 = IsFocusModeActive();
		if (!interacting && !camLocked)
		{
			bool flag4 = false;
			Physics.queriesHitBackfaces = true;
			if (!flag4 && Inventory.IsShowingInventory() && flag)
			{
				Input.GetKeyDown(KeyCode.G);
				flag4 = true;
				hand2.SetInteractionSprite(uiSpriteDict["hand-point"].sprite);
				hand2.HideInteractionSprite();
				Collider collider = null;
				if (collider == null && Physics.Raycast(camTransform.position, camTransform.forward, out var hitInfo, num * 2f, inventoryItemMask))
				{
					UT_HoverInfo component = hitInfo.collider.GetComponent<UT_HoverInfo>();
					if (component != null)
					{
						component.OnHover();
					}
					ObjectTagger component2 = hitInfo.collider.GetComponent<ObjectTagger>();
					if (hand2.GetHandItem() == null)
					{
						if (component2 != null)
						{
							Interaction info = new Interaction
							{
								curhand = hand2,
								fireButton = fireButton,
								tagger = component2,
								clickable = grabAnywhereFakeHandholds[hand2.id],
								player = this
							};
							if (hitInfo.collider.GetComponent<Clickable>().CanInteract(info))
							{
								collider = (hand2.inventoryMemory = hitInfo.collider);
								hand2.inventoryMemoryTime = inventoryGrabForgive;
							}
							else
							{
								hand2.HideInteractionSprite();
								interactRay = false;
							}
						}
						else
						{
							hand2.HideInteractionSprite();
						}
					}
				}
				if (collider == null && hand2.inventoryMemory != null && hand2.inventoryMemoryTime > 0f && hand2.inventoryMemory.gameObject.activeInHierarchy)
				{
					collider = hand2.inventoryMemory;
				}
				if (collider != null)
				{
					ObjectTagger component3 = collider.GetComponent<ObjectTagger>();
					Item_Object component4 = component3.GetComponent<Item_Object>();
					if (component4 != null && component4.itemData.HasTag("unpurchased"))
					{
						hand2.SetInteractionSprite(uiSpriteDict["hand-point"].sprite, uiSpriteDict["hand-shop"].sprite);
					}
					component4.OnHover();
					hand2.ShowInteractionSprite();
					interactRay = true;
					UT_HoverCursor component5 = collider.GetComponent<UT_HoverCursor>();
					if (component5 != null)
					{
						hand2.SetInteractionSprite(component5.GetCursor());
					}
					else if (component3.HasTag("Pickupable"))
					{
						hand2.SetInteractionSprite(uiSpriteDict["hand-point"].sprite);
					}
					if (component3 != null && !interacting && component3.HasTag("Item") && InputManager.GetButton(fireButton).Down && interactRay)
					{
						Item_Object component6 = collider.GetComponent<Item_Object>();
						if (component6.CanPickup())
						{
							if (component3.HasTag("Prop"))
							{
								collider.GetComponent<CL_Prop>().Pickup();
							}
							inventory.AddItemToHand(component6.itemData, hand2);
							collider.gameObject.SetActive(value: false);
							hand2.HideInteractionSprite();
							hand2.cooldown += 0.15f;
							hand2.inventoryMemory = null;
							return;
						}
						hand2.HideInteractionSprite();
					}
				}
			}
			if (!flag4 && !Inventory.IsShowingInventory())
			{
				Input.GetKey(KeyCode.G);
				InteractHit interactHit2 = default(InteractHit);
				int num2 = 0;
				InteractHit interactHit3 = default(InteractHit);
				InteractHit interactHit4 = default(InteractHit);
				int num3 = 0;
				bool flag5 = false;
				bool flag6 = false;
				List<Hand.HandPhysicsHits> interactCasts = hand2.GetInteractCasts();
				UT_HoverInfo uT_HoverInfo = null;
				for (int i = 0; i < interactCasts.Count; i++)
				{
					bool flag7 = false;
					InteractHit interactHit5 = default(InteractHit);
					Hand.HandPhysicsHits handPhysicsHits = interactCasts[i];
					bool num4 = handPhysicsHits.directHit.collider != null && handPhysicsHits.directHit.collider.gameObject.activeInHierarchy;
					bool flag8 = handPhysicsHits.sphereCastHit.collider != null && handPhysicsHits.sphereCastHit.collider.gameObject.activeInHierarchy;
					if (num4 || flag8)
					{
						flag2 = true;
						RaycastHit directHit = handPhysicsHits.directHit;
						RaycastHit hitInfo = handPhysicsHits.sphereCastHit;
						interactHit5 = ((!flag8) ? new InteractHit(directHit) : new InteractHit(hitInfo));
						if (flag)
						{
							hand2.SetInteractionSprite(uiSpriteDict["hand-open"].sprite);
							UT_HoverInfo component7 = interactHit5.collider.GetComponent<UT_HoverInfo>();
							if ((object)component7 != null)
							{
								uT_HoverInfo = component7;
							}
							if (!flag4 && directHit.collider != null)
							{
								ObjectTagger component8 = directHit.collider.GetComponent<ObjectTagger>();
								Clickable component9 = directHit.collider.GetComponent<Clickable>();
								CL_Prop component10 = directHit.collider.GetComponent<CL_Prop>();
								bool flag9 = component9 != null;
								bool flag10 = component10 != null && (component8 == null || !component8.HasTag("GrabInFocus"));
								if (component8 != null && component8.HasTag("InteractBlocker"))
								{
									hand2.HideInteractionSprite();
									flag5 = true;
								}
								if (component8 != null && (flag9 || component8.HasTag("Item") || (component8.HasTag("Handhold") && !flag3)) && (!flag3 || !flag10))
								{
									flag4 = true;
									interactHit5 = new InteractHit(directHit);
									if (!interactHit5.collider.GetComponent<MeshCollider>())
									{
										interactHit5.point = interactHit5.collider.ClosestPoint(interactHit5.point);
									}
									if (CL_UIManager.debug)
									{
										CL_DebugView.draw.SphereOutline(directHit.point, 0.1f, Color.green);
									}
									flag7 = component8.HasTag("Handhold");
								}
								if (component8 != null && component8.HasTag("ForceGrabMemory"))
								{
									flag6 = true;
								}
							}
							if (!flag4 && hitInfo.collider != null)
							{
								ObjectTagger component11 = hitInfo.collider.GetComponent<ObjectTagger>();
								if (component11 != null && component11.HasTag("InteractBlocker"))
								{
									hand2.HideInteractionSprite();
									flag5 = true;
								}
								if (component11 != null && (component11.HasTag("Button") || component11.HasTag("Item") || (component11.HasTag("Handhold") && !flag3)))
								{
									flag4 = true;
									interactHit5 = new InteractHit(hitInfo);
									if (!interactHit5.collider.GetComponent<MeshCollider>())
									{
										interactHit5.point = interactHit5.collider.ClosestPoint(interactHit5.point);
									}
									if (CL_UIManager.debug)
									{
										CL_DebugView.draw.SphereOutline(directHit.point, 0.1f, Color.green);
									}
									flag7 = component11.HasTag("Handhold");
								}
								if (component11 != null && component11.HasTag("ForceGrabMemory"))
								{
									flag6 = true;
								}
							}
							if (!flag4 && handPhysicsHits.lineHit != null && handPhysicsHits.lineHit.Length != 0)
							{
								RaycastHit[] lineHit = handPhysicsHits.lineHit;
								for (int j = 0; j < handPhysicsHits.lineHitCount; j++)
								{
									RaycastHit hit = lineHit[j];
									if (hit.collider == null)
									{
										continue;
									}
									ObjectTagger component12 = hit.collider.GetComponent<ObjectTagger>();
									if (component12 != null && component12.HasTag("Handhold"))
									{
										flag4 = true;
										interactHit5 = new InteractHit(hit);
										flag7 = true;
										if (CL_UIManager.debug)
										{
											CL_DebugView.draw.SphereOutline(hit.point, 0.1f, Color.green);
											CL_DebugView.draw.SphereOutline(hit.point, 0.12f, Color.yellow);
											CL_DebugView.draw.Arrow(directHit.point, hit.point);
										}
										break;
									}
								}
							}
							if (!flag4)
							{
								Collider[] sphereCheck = handPhysicsHits.sphereCheck;
								for (int k = 0; k < handPhysicsHits.sphereCheckCount; k++)
								{
									Collider collider2 = sphereCheck[k];
									ObjectTagger objectTagger = null;
									if (collider2 != null)
									{
										objectTagger = collider2.GetComponent<ObjectTagger>();
									}
									bool flag11 = objectTagger != null && objectTagger.HasTag("Handhold");
									bool flag12 = objectTagger != null && objectTagger.HasTag("Item");
									if (flag11 || flag12)
									{
										flag4 = true;
										flag7 = flag11;
										interactHit5 = new InteractHit(directHit);
										interactHit5.collider = collider2;
										if (CL_UIManager.debug)
										{
											CL_DebugView.draw.SphereOutline(directHit.point, 0.1f, Color.green);
										}
										break;
									}
								}
							}
							if (CL_UIManager.debug && hand == 0)
							{
								CL_DebugView.draw.Label2D(interactHit5.point, interactHit5.collider.name, Color.green);
							}
						}
					}
					if (flag4 && interactHit5.distance > 30f)
					{
						flag4 = false;
						interactHit5 = default(InteractHit);
					}
					if (flag4 && flag7 && !interactHit2.IsValid())
					{
						interactHit2 = interactHit5;
						num2 = i;
					}
					if (flag4 && !flag7 && !interactHit3.IsValid())
					{
						interactHit3 = interactHit5;
						num3 = i;
					}
					if (!interactHit4.IsValid() && interactHit5.collider != null)
					{
						interactHit4 = interactHit5;
					}
					flag4 = false;
				}
				if (uT_HoverInfo != null)
				{
					uT_HoverInfo.OnHover();
				}
				if (!flag4 && flag3 && interactHit3.IsValid())
				{
					interactHit = interactHit3;
					flag4 = true;
				}
				if (!flag4 && !flag3 && interactHit3.IsValid() && interactHit2.IsValid())
				{
					interactHit = ((num3 < num2) ? interactHit3 : interactHit2);
					flag4 = true;
				}
				if (!flag4 && interactHit3.IsValid())
				{
					interactHit = interactHit3;
					flag4 = true;
				}
				if (!flag4 && !flag3 && interactHit2.IsValid())
				{
					interactHit = interactHit2;
					flag4 = true;
				}
				if (flag4 && (flag3 || flag6) && interactHit.IsValid())
				{
					hand2.nohandholdsMemory = interactHit;
					hand2.nohandholdsMemoryTime = grabForgive;
				}
				if (!flag4 && hand2.nohandholdsMemoryTime > 0f && hand2.nohandholdsMemory.collider != null)
				{
					interactHit = hand2.nohandholdsMemory;
				}
				if (!flag4 && flag5)
				{
					hand2.HideInteractionSprite();
				}
				if (!flag5)
				{
					InteractHit hit2 = interactHit;
					if (hand2.grabWait <= 0f && hit2.IsValid() && hit2.collider != null)
					{
						ObjectTagger component13 = hit2.collider.GetComponent<ObjectTagger>();
						if (component13 != null)
						{
							Item_Object component14 = hit2.collider.GetComponent<Item_Object>();
							if (component14 != null)
							{
								component14.OnHover();
							}
							Clickable component15 = hit2.collider.GetComponent<Clickable>();
							if (component15 != null)
							{
								Sprite interactSprite = null;
								Interaction interaction = new Interaction
								{
									interactSettings = new Interaction.InteractSettings
									{
										allowPressHoldInteract = (flag3 || flag6)
									},
									curhand = hand2,
									fireButton = fireButton,
									hitCollider = hit2.collider,
									tagger = component13,
									clickable = component15,
									player = this,
									interactHit = interactHit
								};
								if (hand2.GetHandItem() == null)
								{
									Interact(interaction, ref interacting, ref hit2, out interactSprite);
								}
								else
								{
									interaction.item = hand2.GetHandItem().item;
									hand2.inventoryHand.currentItem.Interact(interaction, ref interacting, ref hit2, out interactSprite);
								}
								interactFound = true;
								flag4 = true;
								interactHit = hit2;
								if (interactSprite != null)
								{
									hand2.ShowInteractionSprite();
									hand2.SetInteractionSprite(interactSprite, interaction.interactOverlaySprite);
								}
								else
								{
									hand2.HideInteractionSprite();
								}
							}
						}
					}
					if (!flag4 && interactHit4.IsValid() && !hands[hand].inventoryHand.HasItem() && !flag3)
					{
						ObjectTagger component16 = interactHit4.collider.GetComponent<ObjectTagger>();
						flag4 = GrabAnywhere(hand2, ref interacting, fireButton, ref interactHit4, interactFound, ref component16);
					}
				}
				if (interactHit.collider == null && interactHit4.IsValid() && interactHit4.collider != null)
				{
					interactHit = interactHit4;
				}
			}
			if (!flag4)
			{
				hand2.HideInteractionSprite();
				interactRay = false;
			}
		}
		if (flag2)
		{
			AimCircle(interactHit, hand2);
		}
		Physics.queriesHitBackfaces = false;
		if (flag2)
		{
			if (InputManager.GetButton(hand2.throwButton).Down && hand2.GetHandItem() != null)
			{
				inventory.DropItemFromHand(interactHit.point + interactHit.normal * 0.1f - camTransform.forward * 0.3f, hand);
				return;
			}
		}
		else if (InputManager.GetButton(hand2.throwButton).Down && hand2.GetHandItem() != null)
		{
			inventory.DropItemFromHand(camTransform.position + camTransform.forward, hand);
			return;
		}
		if (hand2.memoryTime > 0f && hand2.grabWait < 0f && !IsNullOrDestroyed(hand2.holdMemory) && flag && !flag3)
		{
			Clickable holdMemory = hand2.holdMemory;
			ObjectTagger objectTagger2 = holdMemory.GetTagger();
			Interaction interaction2 = new Interaction
			{
				curhand = hand2,
				fireButton = fireButton,
				tagger = objectTagger2,
				clickable = grabAnywhereFakeHandholds[hand2.id],
				player = this
			};
			if (holdMemory.CanInteract(interaction2))
			{
				if (hand2.GetHandItem() != null && !interacting)
				{
					if (hand2.GetHandItem().UseGrabMemory())
					{
						interacting = true;
						Sprite interactSprite2 = null;
						bool interacting2 = false;
						interaction2 = new Interaction
						{
							curhand = hand2,
							fireButton = hand2.fireButton,
							hitCollider = hand2.holdMemoryHit.collider,
							tagger = objectTagger2,
							clickable = holdMemory,
							interactSettings = new Interaction.InteractSettings
							{
								allowMemorySave = false,
								allowPressHoldInteract = true
							},
							player = this
						};
						hand2.GetHandItem().item.Interact(interaction2, ref interacting2, ref hand2.holdMemoryHit, out interactSprite2);
						hand2.SetInteractionSprite(interactSprite2);
					}
				}
				else
				{
					hand2.ShowInteractionSprite();
					interactRay = true;
					UT_HoverCursor component17 = holdMemory.GetGameObject().GetComponent<UT_HoverCursor>();
					if (component17 != null)
					{
						hand2.SetInteractionSprite(component17.GetCursor());
					}
					else if (objectTagger2.HasTag("Pickupable"))
					{
						hand2.SetInteractionSprite(uiSpriteDict["hand-open"].sprite);
					}
					else if (objectTagger2.HasTag("Button"))
					{
						hand2.SetInteractionSprite(uiSpriteDict["hand-point"].sprite);
					}
				}
			}
			else
			{
				hand2.HideInteractionSprite();
				interactRay = false;
			}
			if (InputManager.GetButton(fireButton).Pressed && !interacting && hand2.GetHandItem() == null && IsNullOrDestroyed(hand2.currentInteract) && holdMemory.CanInteract(interaction2))
			{
				interacting = true;
				hand2.currentInteract = holdMemory;
				Clickable.InteractionInfo interactionInfo = Clickable.InteractionInfo.CreateNewInfo(this, hand2);
				interactionInfo.interactionPoint = holdMemory.GetGameObject().transform.TransformPoint(hand2.holdMemoryPosition);
				interactionInfo.interactionDirection = camTransform.forward;
				interactionInfo.interactionNormal = -camTransform.forward;
				Transform onTransform = null;
				if (hand2.holdMemoryHit.collider != null)
				{
					onTransform = hand2.holdMemoryHit.collider.transform;
				}
				GoopedDecal(hand2.holdMemoryHit.point, hand2.holdMemoryHit.normal, camTransform.forward, onTransform);
				if (((curBuffs.GetBuff("grabAnything") > 0f && !HasEffect("wet")) || forceGrabAnywhere) && holdMemory == grabAnywhereFakeHandholds[hand])
				{
					hand2.GrabHold(holdMemory.GetGameObject().transform, holdMemory.GetGameObject().transform.position, interactionInfo);
				}
				else
				{
					hand2.GrabHold(holdMemory.GetGameObject().transform, holdMemory.GetGameObject().transform.TransformPoint(hand2.holdMemoryPosition), interactionInfo);
				}
			}
		}
		if (interacting && flag && InputManager.GetButton(fireButton).Up && (!IsNullOrDestroyed(hand2.currentInteract) || hand2.grabTarget != null) && (hand2.interactState == InteractType.hold || hand2.interactState == InteractType.grab || hand2.interactState == InteractType.hanging))
		{
			StopInteraction(hand);
		}
		HandAnimation(hand2, interacting, flag);
		HandStamina(hand, hand2, flag, interacting, num);
	}

	private bool GrabAnywhere(Hand curhand, ref bool interacting, string fireButton, ref InteractHit interactHit, bool interactFound, ref ObjectTagger tagger)
	{
		bool result = false;
		if (((curBuffs.GetBuff("grabAnything") > 0f && !HasEffect("wet")) || forceGrabAnywhere) && curhand.grabWait <= 0f && !interacting && !interactFound && curhand.interactState == InteractType.none && curhand.handhold != grabAnywhereFakeHandholds[curhand.id])
		{
			result = true;
			grabAnywhereFakeHandholds[curhand.id].gameObject.SetActive(value: true);
			grabAnywherePosition[curhand.id] = interactHit.transform.InverseTransformPoint(interactHit.point);
			tagger = grabAnywhereFakeHandholds[curhand.id].GetTagger();
			grabAnywhereHit[curhand.id] = interactHit.transform;
			Sprite interactSprite = uiSpriteDict["hand-open"].sprite;
			Interaction interaction = new Interaction
			{
				curhand = curhand,
				fireButton = fireButton,
				tagger = tagger,
				clickable = grabAnywhereFakeHandholds[curhand.id],
				player = this,
				interactHit = interactHit
			};
			Interact(interaction, ref interacting, ref interactHit, out interactSprite);
			curhand.SetInteractionSprite(interactSprite, interaction.interactOverlaySprite);
			curhand.holdPosition = Vector3.zero;
		}
		else
		{
			grabAnywhereFakeHandholds[curhand.id].gameObject.SetActive(value: false);
		}
		return result;
	}

	private void HandStamina(int hand, Hand curhand, bool canInteract, bool interacting, float currentInteractDistance)
	{
		float currentGripStrengthTimer = GetCurrentGripStrengthTimer(hand);
		DebugMenu.UpdateDebugText("gripstrengthtimer", "Max Grip Strength Timer: " + currentGripStrengthTimer);
		DebugMenu.UpdateDebugText("gripstrength", "Current Grip Strength: " + curhand.gripStrength);
		if (infiniteStamina)
		{
			curhand.gripStrength = currentGripStrengthTimer;
		}
		if (interacting && canInteract)
		{
			if (curhand.interactState == InteractType.hanging && !IsNullOrDestroyed(curhand.currentInteract))
			{
				curhand.holdTime += Time.deltaTime;
				if (!isGrounded || grappled)
				{
					float num = 1f;
					if (curhand.handhold != null)
					{
						num *= curhand.handhold.strainRate;
					}
					float num2 = 1f;
					if (isResting)
					{
						num2 /= 1f + curBuffs.GetBuff("addStillGripStrength");
					}
					curhand.gripStrength = Mathf.Clamp(curhand.gripStrength - Time.deltaTime * (gripStrengthLossRate / (curBuffs.GetBuff("addGripStrength") + GetBuffOnHand("addGripStrength", hand) + 1f) * num2) * num, 0f, currentGripStrengthTimer);
				}
				else
				{
					curhand.gripStrength = Mathf.Clamp(curhand.gripStrength + Time.deltaTime * 0.75f, 0f, currentGripStrengthTimer);
				}
			}
			else if ((curhand.interactState == InteractType.grab || curhand.interactState == InteractType.hold) && !IsNullOrDestroyed(curhand.currentInteract))
			{
				curhand.holdTime = 0f;
				curhand.gripStrength = Mathf.Clamp(curhand.gripStrength + Time.deltaTime * 0.5f, 0f, currentGripStrengthTimer);
				if (curhand.interactState == InteractType.grab)
				{
					GrabPropUpdate(hand);
				}
				if (curhand.interactState == InteractType.hold && curhand.holdTarget != null)
				{
					HandItem handItem = curhand.GetHandItem();
					Vector3 vector = ((!(handItem == null)) ? handItem.transform.position : curhand.handBase.transform.position);
					float num3 = Vector3.Distance(base.transform.position, vector);
					if (num3 > currentInteractDistance * 1.1f)
					{
						StopInteraction(hand);
					}
					else if (num3 > currentInteractDistance * 0.9f)
					{
						AddForce((vector - base.transform.position) * Time.deltaTime * 1.1f);
					}
				}
			}
		}
		else
		{
			curhand.holdTime = 0f;
			float buff = curBuffs.GetBuff("addStaminaRegen");
			float num4 = Mathf.Max(1f + buff, 0f);
			if (isGrounded)
			{
				curhand.gripStrength = Mathf.Clamp(curhand.gripStrength + Time.deltaTime * 0.9f * num4, 0f, currentGripStrengthTimer);
				curhand.gripStrength += curBuffs.GetBuff("addGroundedStaminaRegen") * Time.deltaTime;
			}
			else if (curhand.CanRegenerate())
			{
				curhand.gripStrength = Mathf.Clamp(curhand.gripStrength + Time.deltaTime * 0.75f * num4, 0f, currentGripStrengthTimer);
			}
		}
		if (curhand.gripStrength <= 0.1f && curhand.grabWait < 0.1f)
		{
			clipHandler.GetGroup("fatigue").GetSet("drop").Play(1f, audioChannels[1]);
			StopInteraction(hand);
			curhand.grabWait = 1f;
		}
		else
		{
			curhand.gripStrength = Mathf.Clamp(curhand.gripStrength + Time.deltaTime * curBuffs.GetBuff("regenerateGripStrength"), 0f, currentGripStrengthTimer);
		}
	}

	private void HandAnimation(Hand curhand, bool interacting, bool canInteract)
	{
		string fireButton = curhand.fireButton;
		GetCurrentGripStrengthTimer(curhand.id);
		float num = Mathf.Clamp01(1f - curhand.gripStrength / gripStrengthTimer);
		if (interacting && canInteract)
		{
			if (curhand.interactState == InteractType.hanging && !IsNullOrDestroyed(curhand.currentInteract))
			{
				if (num > 0.92f)
				{
					CL_CameraControl.Shake(0.0005f * num);
				}
				curhand.SetInteractionSprite(uiSpriteDict["hand-grabbed"].sprite);
				Vector3 vector = UnityEngine.Random.insideUnitSphere * (num + curhand.GetShake() * 10f);
				if (!curhand.IsLocked())
				{
					if (curhand.GetHandItem() != null)
					{
						curhand.GetHandItem().transform.position = curhand.currentInteract.GetGameObject().transform.TransformPoint(curhand.holdPosition) + vector * 0.02f;
						curhand.GetHandItem().transform.rotation = Quaternion.LookRotation(curhand.GetHandItem().transform.position - cam.transform.position, cam.transform.up);
					}
					else
					{
						curhand.handModel.position = curhand.currentInteract.GetGameObject().transform.TransformPoint(curhand.holdPosition) + vector * 0.02f;
						curhand.handModel.rotation = Quaternion.LookRotation(curhand.handModel.position - (cam.transform.position - cam.transform.forward), cam.transform.up);
						curhand.SetSprite(curhand.GetPoseSprite("grab"));
					}
				}
			}
			else if ((curhand.interactState == InteractType.grab || curhand.interactState == InteractType.hold) && !IsNullOrDestroyed(curhand.currentInteract))
			{
				if (!curhand.IsLocked())
				{
					HandItem handItem = curhand.GetHandItem();
					if (handItem != null)
					{
						handItem.transform.position = curhand.currentInteract.GetGameObject().transform.TransformPoint(curhand.holdPosition);
						handItem.transform.rotation = Quaternion.LookRotation(handItem.transform.position - (cam.transform.position - cam.transform.forward), cam.transform.up);
					}
					else
					{
						curhand.handModel.position = curhand.currentInteract.GetGameObject().transform.TransformPoint(curhand.holdPosition);
						curhand.handModel.rotation = Quaternion.LookRotation(curhand.handModel.position - (cam.transform.position - cam.transform.forward), cam.transform.up);
						curhand.SetSprite(curhand.GetPoseSprite("grab"));
					}
				}
				curhand.SetSprite(curhand.GetPoseSprite("grab"));
			}
		}
		else
		{
			curhand.ShakeHand(num * Time.deltaTime * 0.04f);
			curhand.IsLocked();
			if (isSwimming)
			{
				curhand.GetViewSway().SetCustomParameters(swimViewSwayParameters);
			}
			else if (!IsGrounded(includeCoyoteTime: true) && cCon.velocity.y < 0f)
			{
				if (curFallDistance > 15f)
				{
					curhand.GetViewSway().SetCustomParameters(longFallViewSwayParameters);
				}
				else
				{
					curhand.GetViewSway().SetCustomParameters(airbornViewSwayParameters);
				}
			}
			else if (IsSprinting() && curhand.CanUseSpecialPoseSprite("sprint") && timeSinceSprinting > 0.1f && timeSinceGrounded < 0.1f && !SettingsManager.settings.disableSprintAnim)
			{
				if (!CanUseSprintAnimations())
				{
					curhand.GetViewSway().SetCustomParameters(itemViewSwayParameters);
				}
				else
				{
					curhand.GetViewSway().SetCustomParameters(sprintViewSwayParameters);
				}
			}
			else
			{
				curhand.GetViewSway().UnsetCustomParameters();
			}
			if (canInteract)
			{
				if (InputManager.GetButton(fireButton).Pressed)
				{
					curhand.SetSprite(curhand.GetPoseSprite("open"));
					if (IsSprinting())
					{
						curhand.GetViewSway().UnsetCustomParameters();
					}
				}
				else if (IsCrouching() && curhand.CanUseSpecialPoseSprite("crouch"))
				{
					curhand.SetSprite(curhand.GetPoseSprite("crouch"));
				}
				else if (IsSprinting() && !isSwimming && curhand.CanUseSpecialPoseSprite("sprint") && CanUseSprintAnimations() && timeSinceSprinting > 0.3f && cCon.velocity.magnitude > 0.3f && IsGrounded(includeCoyoteTime: true) && !SettingsManager.settings.disableSprintAnim)
				{
					curhand.SetSprite(curhand.GetPoseSprite("sprint"));
				}
				else
				{
					curhand.SetSprite(curhand.GetPoseSprite("normal"));
				}
			}
		}
		Color b = Color.white;
		if (curBuffs.GetBuff("grabAnything") > 0f && !HasEffect("wet"))
		{
			b = Color.Lerp(Color.yellow, b, 1f - curBuffs.GetBuff("gooped"));
		}
		b = Color.Lerp(new Color(0f, 0.4812922f, 1f), b, 1f - curBuffs.GetBuff("pilled") * 0.5f * (Mathf.Sin(Time.time * 6f) / 2f + 0.5f));
		b = Color.Lerp(new Color(0.8084344f, 101f / 106f, 0.2921413f), b, 1f - curBuffs.GetBuff("boosted") * 0.5f * (Mathf.Sin(Time.time * 6f) / 2f + 0.5f));
		float t = Mathf.Round(curhand.gripStrength / gripStrengthTimer * 6f) / 6f;
		Color color = Color.Lerp(curhand.GetStaminaDrainIconColor(), b, t);
		curhand.uiInteract.color = color;
		curhand.handSprite.color = b;
		if (curhand.GetHandItem() != null)
		{
			curhand.GetHandItem().SetHandColor(b);
		}
	}

	public void Interact(Interaction interaction, ref bool interacting, ref InteractHit hit, out Sprite interactSprite)
	{
		if (interaction.interactSettings == null)
		{
			interaction.interactSettings = new Interaction.InteractSettings();
		}
		if ((useInteractWhitelist && !interaction.tagger.HasTagInList(interactWhitelist.ToArray())) || interaction.curhand.IsLocked())
		{
			interactSprite = null;
			interactRay = false;
			interacting = false;
			return;
		}
		float num = GetInteractDistance(interaction.curhand.id);
		Sprite sprite = null;
		bool flag = false;
		if (interaction.clickable.CanInteract(interaction))
		{
			if (interaction.tagger.HasTag("Handhold"))
			{
				if (interaction.interactSettings.allowMemorySave)
				{
					interaction.curhand.memoryTime = grabForgive;
					interaction.curhand.holdMemory = interaction.clickable;
					interaction.curhand.holdMemoryPosition = interaction.clickable.GetGameObject().transform.InverseTransformPoint(hit.point);
					interaction.curhand.holdMemoryHit = hit;
				}
			}
			else if (interaction.tagger.HasTag("Button") && hit.IsValid() && hit.distance > num * 0.85f)
			{
				interactSprite = null;
				interactRay = false;
				interacting = false;
				return;
			}
			interactRay = true;
			UT_HoverCursor uT_HoverCursor = null;
			if ((bool)interaction.hitCollider)
			{
				uT_HoverCursor = interaction.hitCollider.GetComponent<UT_HoverCursor>();
			}
			if (uT_HoverCursor != null)
			{
				sprite = uT_HoverCursor.GetCursor();
			}
			else if (interaction.tagger.HasTag("Pickupable"))
			{
				sprite = uiSpriteDict["hand-open"].sprite;
			}
			else if (interaction.tagger.HasTag("Handhold"))
			{
				sprite = uiSpriteDict["hand-open"].sprite;
			}
			else if (interaction.tagger.HasTag("Button"))
			{
				sprite = uiSpriteDict["hand-point"].sprite;
			}
			else if (interaction.tagger.HasTag("Item"))
			{
				Item_Object component = interaction.tagger.GetComponent<Item_Object>();
				if (component != null && component.itemData.HasTag("unpurchased"))
				{
					interaction.interactOverlaySprite = uiSpriteDict["hand-shop"].sprite;
				}
				sprite = uiSpriteDict["hand-item"].sprite;
			}
		}
		else
		{
			flag = true;
			interactRay = false;
		}
		bool flag2 = InputManager.GetButton(interaction.fireButton).Down;
		if (interaction.interactSettings.allowPressHoldInteract && InputManager.GetButton(interaction.fireButton).Pressed)
		{
			flag2 = true;
		}
		if (flag2 && interactRay && !interacting)
		{
			Clickable.InteractionInfo interactionInfo = new Clickable.InteractionInfo();
			interactionInfo.player = this;
			interactionInfo.hand = interaction.curhand;
			interactionInfo.interactionPoint = hit.point;
			interactionInfo.interactionNormal = hit.normal;
			interactionInfo.interactionDirection = camTransform.forward;
			if (interaction.tagger.HasTag("Item"))
			{
				Item_Object item_Object = null;
				item_Object = ((!hit.IsValid()) ? interaction.tagger.GetComponent<Item_Object>() : hit.collider.GetComponent<Item_Object>());
				if (item_Object.CanPickup() && !item_Object.itemData.InHand())
				{
					if (interaction.tagger.HasTag("Prop"))
					{
						interaction.hitCollider?.GetComponent<CL_Prop>().Pickup();
					}
					inventory.AddItemToHand(item_Object.itemData, interaction.curhand);
					interaction.hitCollider?.gameObject.SetActive(value: false);
					flag = true;
					interaction.curhand.holdMemory = null;
					interaction.curhand.memoryTime = 0f;
				}
				else
				{
					flag = true;
				}
			}
			else if (interaction.tagger.HasTag("Pickupable"))
			{
				CL_Prop cL_Prop = (hit.IsValid() ? hit.collider.GetComponent<CL_Prop>() : interaction.tagger.GetComponent<CL_Prop>());
				if (cL_Prop != null && cL_Prop.enabled)
				{
					if (hit.IsValid())
					{
						interaction.curhand.grabTarget = cL_Prop;
						interaction.curhand.holdTarget = hit.transform;
					}
					else
					{
						interaction.curhand.grabTarget = cL_Prop;
						interaction.curhand.holdTarget = interaction.tagger.transform;
					}
					sprite = uiSpriteDict["hand-grabbed"].sprite;
					interacting = true;
					if (hit.IsValid())
					{
						interaction.curhand.holdPosition = interaction.clickable.GetGameObject().transform.InverseTransformPoint(hit.point);
					}
					else
					{
						interaction.curhand.holdPosition = interaction.clickable.GetGameObject().transform.InverseTransformPoint(interaction.tagger.transform.position);
					}
					interaction.curhand.currentInteract = interaction.clickable;
					interaction.curhand.currentInteract.Interact(interactionInfo);
					if (interaction.curhand.grabTarget != null)
					{
						holdDistance = interaction.curhand.grabTarget.holdDistance;
					}
					else
					{
						holdDistance = 1.8f;
					}
					interaction.curhand.interactState = InteractType.grab;
					if (hit.IsValid())
					{
						interaction.curhand.grabTarget.anchorPoint = interaction.curhand.grabTarget.transform.InverseTransformPoint(hit.point);
					}
					else
					{
						interaction.curhand.grabTarget.anchorPoint = interaction.curhand.grabTarget.transform.InverseTransformPoint(interaction.tagger.transform.position);
					}
					interaction.curhand.OnInteract();
				}
			}
			else if (interaction.tagger.HasTag("Button"))
			{
				if (interaction.clickable.CanInteract(interaction))
				{
					interaction.clickable.Interact(interactionInfo);
					flag = true;
					interaction.curhand.interactState = InteractType.none;
					interaction.curhand.OnInteract();
				}
			}
			else if (interaction.tagger.HasTag("HoldButton"))
			{
				if (interaction.clickable.CanInteract(interaction))
				{
					interaction.curhand.currentInteract = interaction.clickable;
					interaction.curhand.currentInteract.Interact(interactionInfo);
					interaction.curhand.GrabTarget(interaction.clickable.GetGameObject().transform, hit.point);
					interacting = true;
					interaction.curhand.holdTarget = interaction.clickable.GetGameObject().transform;
					interaction.curhand.interactState = InteractType.hold;
					interaction.curhand.OnInteract();
				}
			}
			else if (interaction.tagger.HasTag("Handhold") && interaction.clickable.CanInteract(interaction))
			{
				interacting = true;
				Transform onTransform = null;
				if (interaction.interactHit.collider != null)
				{
					onTransform = interaction.interactHit.collider.transform;
				}
				GoopedDecal(interaction.interactHit.point, interaction.interactHit.normal, interaction.player.transform.forward, onTransform);
				if ((bool)interaction.hitCollider)
				{
					interaction.curhand.GrabHold(interaction.hitCollider.transform, hit.point, interactionInfo);
				}
				else
				{
					interaction.curhand.GrabHold(interaction.clickable.GetGameObject().transform, hit.point, interactionInfo);
				}
				if (interaction.curhand.currentInteract != null)
				{
					sprite = uiSpriteDict["hand-grabbed"].sprite;
				}
				else
				{
					interacting = false;
				}
			}
		}
		interactSprite = sprite;
		if (flag)
		{
			interactSprite = null;
		}
		else if (sprite == null)
		{
			interactSprite = uiSpriteDict["hand-open"].sprite;
		}
	}

	private void GoopedDecal(Vector3 point, Vector3 normal, Vector3 up, Transform onTransform)
	{
		if (curBuffs.GetBuff("gooped") > 0f)
		{
			FXManager.DecalHandle handle = FXManager.DecalCreate(FXManager.DecalPriority.Low);
			FXManager.DecalPointingFrom(handle, point, normal, base.transform.forward, onTransform);
			FXManager.DecalSharedApply(handle, FXManager.DecalSharedData(goopedDecal));
			FXManager.DecalColor(handle, DarkMachineCrayons.yellowGreen);
			FXManager.DecalFadeout(handle, 4f, 1f);
		}
	}

	public void StopInteraction(int hand, string type = "", bool addWait = true)
	{
		Hand hand2 = hands[hand];
		hand2.SetRegenWait(0.17f);
		camLocked = false;
		if (!IsNullOrDestroyed(hand2.currentInteract))
		{
			hand2.OnLetGo();
			hand2.currentInteract.StopInteract(this, hand2, type);
			if (hand2.currentInteract.GetTagger() != null)
			{
				if (hand2.currentInteract.GetTagger().HasTag("Handhold"))
				{
					hand2.holdTarget = null;
					if (addWait)
					{
						hand2.grabWait += 0.25f;
					}
					clipHandler.GetGroup("climbing").GetSet("drop").Play(1f, audioChannels[0]);
					hand2.handhold = null;
					hand2.holdMemory = null;
					hand2.memoryTime = 0f;
				}
				else if (hand2.currentInteract.GetTagger().HasTag("HoldButton"))
				{
					hand2.holdTarget.GetComponent<CL_HoldButton>();
					hand2.holdTarget = null;
					hand2.grabWait += 0.25f;
					clipHandler.GetGroup("climbing").GetSet("drop").Play(1f, audioChannels[0]);
					hand2.holdMemory = null;
					hand2.memoryTime = 0f;
				}
			}
		}
		DropGrabbedProp(hand, type);
		hand2.grabTarget = null;
		hand2.currentInteract = null;
		hand2.SetInteractionSprite(uiSpriteDict["hand-open"].sprite);
		hand2.interactState = InteractType.none;
	}

	public void GrabPropUpdate(int hand)
	{
		string fireButton = hands[hand].fireButton;
		Hand hand2 = hands[hand];
		if (hand2.grabTarget == null || !hand2.grabTarget.gameObject.activeInHierarchy)
		{
			DropGrabbedProp(hand);
		}
		else
		{
			if (hand2.interactState != InteractType.grab)
			{
				return;
			}
			Rigidbody rigidbody = hand2.grabTarget.GetRigidbody();
			hand2.grabTarget.gameObject.GetComponent<ObjectTagger>();
			Vector3 vector = Vector3.Lerp(hand2.grabTarget.transform.TransformPoint(hand2.grabTarget.anchorPoint), hand2.grabTarget.transform.position, 0.01f);
			Vector3 vector2 = camTransform.position + camTransform.forward * holdDistance - vector;
			Vector3 holdOffset = hand2.grabTarget.holdOffset;
			if (hand == 1)
			{
				holdOffset.x = 0f - holdOffset.x;
			}
			vector2 += camTransform.TransformVector(holdOffset);
			Vector3 force = 200f * Time.deltaTime * (camTransform.position + camTransform.forward * holdDistance - hand2.grabTarget.transform.TransformPoint(hand2.grabTarget.anchorPoint));
			bool flag = false;
			if (hand2.grabTarget.GetColliders().Contains(cConHit.collider) && base.transform.position.y - 0.25f > vector.y)
			{
				flag = true;
			}
			if (hand2.holdTarget != null)
			{
				Vector3 vector3 = vector;
				if (CL_UIManager.debug)
				{
					CL_DebugView.draw.SphereOutline(vector3, 0.1f, Color.yellow);
				}
				if (Vector3.Distance(vector3, base.transform.position) > interactDistance * 1.1f)
				{
					float magnitude = hand2.grabTarget.GetRigidbody().linearVelocity.magnitude;
					magnitude = Mathf.Clamp01(1f - magnitude);
					Vector3 vector4 = vector3 - base.transform.position;
					float num = vector4.magnitude - interactDistance * 0.5f;
					AddForce(vector4 * num * Time.deltaTime * propHangForce * magnitude);
				}
			}
			if (hand2.grabTarget.stuck)
			{
				hand2.grabTarget.AddBreakingVelocity(vector2 / rigidbody.mass);
				CL_CameraControl.Shake((vector2 / rigidbody.mass).magnitude * 0.0007f);
				hand2.gripStrength -= Time.deltaTime * 2f;
			}
			else if (!flag)
			{
				rigidbody.linearVelocity = vector2 / rigidbody.mass * 8f + Vector3.down * rigidbody.mass;
				rigidbody.AddForceAtPosition(force, hand2.grabTarget.transform.TransformPoint(hand2.grabTarget.anchorPoint));
			}
			float num2 = 0f;
			if (hand2.grabTarget.stuck)
			{
				num2 = hand2.grabTarget.stuckStrength * 0.25f;
			}
			camSpeed = Mathf.Clamp(1f - rigidbody.mass * 0.25f - num2, 0.1f, 1f);
			if (InputManager.GetButton("Rotate").Pressed && !rigidbody.freezeRotation)
			{
				rigidbody.AddTorque((InputManager.GetVector("Look").vector.y * base.transform.right + base.transform.up * (0f - InputManager.GetVector("Look").vector.x)) / (rigidbody.mass * 6f), ForceMode.VelocityChange);
				camLocked = true;
			}
			else
			{
				camLocked = false;
			}
			float num3 = Vector3.Distance(base.transform.position, hand2.grabTarget.transform.TransformPoint(hand2.grabTarget.anchorPoint));
			if (InputManager.GetButton(hand2.throwButton).Down)
			{
				rigidbody.AddForce(camTransform.forward * 150f);
				StopInteraction(hand);
			}
			else if (InputManager.GetButton(fireButton).Up || num3 > interactDistance * 1.5f)
			{
				DropGrabbedProp(hand);
			}
		}
	}

	private void DropGrabbedProp(int hand, string type = "")
	{
		camSpeed = 1f;
		if (hands[hand].grabTarget != null)
		{
			hands[hand].grabTarget.GetRigidbody().linearVelocity = Vector3.ClampMagnitude(hands[hand].grabTarget.GetRigidbody().linearVelocity, Mathf.Clamp(10f - hands[hand].grabTarget.GetRigidbody().mass, 1f, 10f));
			hands[hand].grabTarget.Drop();
			hands[hand].grabTarget.StopInteract(this, hands[hand], type);
		}
		hands[hand].interactState = InteractType.none;
		hands[hand].grabTarget = null;
		hands[hand].currentInteract = null;
		hands[hand].holdTarget = null;
		camLocked = false;
	}

	private void PlayHandholdSound(string handholdMaterial)
	{
		if (handholdMaterial != "standard" && clipHandler.HasSound("climbing:handhold-" + handholdMaterial))
		{
			clipHandler.GetGroup("climbing").GetSet("handhold-" + handholdMaterial).Play(1f, audioChannels[3]);
		}
		else
		{
			clipHandler.GetGroup("climbing").GetSet("handhold").Play(1f, audioChannels[3]);
		}
	}

	public void SetInteractWhitelist(List<string> whitelistTags)
	{
		interactWhitelist = whitelistTags;
		useInteractWhitelist = true;
	}

	public void StopInteractWhitelist()
	{
		useInteractWhitelist = false;
	}

	public float GetInteractDistance(int id = -1)
	{
		float buffOnHand = GetBuffOnHand("addReach", id);
		return interactDistance * (1f + curBuffs.GetBuff("addReach") + buffOnHand) * (1f + curBuffs.GetBuff("addPlayerScale"));
	}

	public float GetBaseInteractDistance()
	{
		return interactDistance * (1f + curBuffs.GetBuff("addPlayerScale"));
	}

	internal bool IsInCutsceneMode()
	{
		return cutsceneMode;
	}

	private void Movement()
	{
		if (!float.IsFinite(vel.x) || !float.IsFinite(vel.y) || !float.IsFinite(vel.z))
		{
			Debug.LogError($"Player velocity was invalid ({vel})! Resetting to zero.");
			vel = Vector3.zero;
		}
		AIGameEntity.Grappler.GrappleInfo averageGrappleInfo = GetAverageGrappleInfo();
		bool flag = grappled && averageGrappleInfo.forcePlayerCrouched;
		if (grappled)
		{
			_ = averageGrappleInfo.forcePlayerGrounded;
		}
		else
			_ = 0;
		float num = (grappled ? averageGrappleInfo.playerGrappleSpeedMod : 1f);
		timeSinceJumpBoost += Time.fixedDeltaTime;
		if (forceAirbornTime > 0f)
		{
			isGrounded = false;
			wasGrounded = false;
		}
		if (isGrounded && !cCon.isGrounded && vel.y < 0f && !isSliding)
		{
			vel.y = 0f;
		}
		bool flag2 = crouching && curBuffs.GetBuff("addJumpBoost") > 0f && IsGrounded(includeCoyoteTime: true) && GetLowestGripStrength() > 2f;
		if (flag2 && !isGrounded)
		{
			clipHandler.GetGroup("perk").GetSet("jumpboost-prime").Play(1f, audioChannels[2]);
		}
		if (forceAirbornTime > 0f)
		{
			forceAirbornTime -= Time.deltaTime;
			isGrounded = false;
		}
		else
		{
			isGrounded = cCon.isGrounded;
		}
		inputAxis = new Vector3(InputManager.GetVector("Move").vector.x, InputManager.GetVector("Move").vector.y, 0f);
		if (IsMoveLocked())
		{
			inputAxis = Vector2.zero;
		}
		Vector3 vector = base.transform.forward;
		Vector3 vector2 = base.transform.right;
		if (IsGrounded() && Physics.Raycast(base.transform.position, -base.transform.up, out var hitInfo, cCon.height, parentMask) && !noclip && Vector3.Dot(hitInfo.normal, GetPlayerUpVector()) > 0.4f)
		{
			vector = Vector3.ProjectOnPlane(vector, hitInfo.normal).normalized;
			vector2 = Vector3.ProjectOnPlane(vector2, hitInfo.normal).normalized;
		}
		if (isSwimming || fly)
		{
			vector = cam.transform.forward;
		}
		float moveLerp = curFootstep.moveLerp;
		Vector3 b = ((playerState == PlayerState.hanging) ? Vector3.zero : (vector * inputAxis.y)) + vector2 * inputAxis.x;
		if (wasSwimming && !isSwimming)
		{
			wasSwimming = false;
			if (InputManager.GetButton("Jump").Pressed)
			{
				Jump(canJumpBoost: false, 0.7f);
			}
		}
		if (isSwimming || fly)
		{
			if (InputManager.GetButton("Jump").Pressed)
			{
				b += GetPlayerUpVector();
			}
			if (InputManager.GetButton("Crouch").Pressed)
			{
				b += -GetPlayerUpVector();
			}
			moveLerp *= 0.5f;
		}
		moveAxis = Vector3.Lerp(moveAxis, b, Time.fixedDeltaTime * 100f * curFootstep.moveLerp);
		moveAxis = Vector3.ClampMagnitude(moveAxis, 1f);
		jumpDir = GetPlayerUpVector();
		float curSpeed = speed;
		float num2 = 1f * frameSpeedMult * speedMult;
		frameSpeedMult = 1f;
		if (isSwimming)
		{
			curSpeed = swimSpeed;
		}
		float num3 = gravity * gravityMult * Mathf.Max(1f + curBuffs.GetBuff("addGravity"), 0.2f) * tempGravityMult;
		if (!hasGravity || isSwimming || fly)
		{
			num3 = 0f;
		}
		playerState = PlayerState.airborne;
		float curDrag = dragCoefficient * tempFrictionMult;
		bool flag3 = IsHanging();
		if (flag3)
		{
			playerState = PlayerState.hanging;
		}
		if (!cCon.isGrounded)
		{
			isGrounded = false;
			if (!IsHanging() && hitTime <= 0f)
			{
				hitNormal = GetPlayerUpVector();
			}
		}
		else if (extraJumpsRemaining < extraJumps + Mathf.CeilToInt(curBuffs.GetBuff("addExtraJumps")))
		{
			extraJumpsRemaining = Mathf.Max(extraJumpsRemaining, extraJumps + Mathf.CeilToInt(curBuffs.GetBuff("addExtraJumps")));
			clipHandler.GetGroup("perk").GetSet("doublejump-recharge").Play(1f);
		}
		float num4 = Vector3.Angle(GetPlayerUpVector(), hitNormal);
		bool flag4 = num4 >= slopeLimit && num4 <= slopeMax;
		isSliding = flag4;
		if (isSliding)
		{
			Vector3 vector3 = -MostYFacingPerpendicular(hitNormal);
			Vector3 zero = Vector3.zero;
			zero += hitNormal * Time.fixedDeltaTime * slideSpeed * (num4 / 90f);
			curSpeed *= 0.5f;
			jumpDir = GetPlayerUpVector();
			float num5 = Vector3.Angle(hitNormal, GetPlayerUpVector());
			if (num5 < 90f && num5 > 20f)
			{
				jumpDir = Vector3.Lerp(hitNormal, GetPlayerUpVector(), 0.9f).normalized;
			}
			else if (num5 > 90f && num5 < 140f && flag3)
			{
				jumpDir = -vector3 + hitNormal * 0.1f;
			}
			else
			{
				jumpDir = GetPlayerUpVector();
			}
			vel += zero * Time.fixedDeltaTime;
			DebugMenu.UpdateDebugText("player-slideBool", "Sliding");
		}
		else
		{
			DebugMenu.UpdateDebugText("player-slideBool", "Not Sliding");
		}
		DebugMenu.UpdateDebugText("player-grounded", "Grounded: " + cCon.isGrounded);
		if (isGrounded && playerState != PlayerState.hanging)
		{
			playerState = PlayerState.grounded;
			timeSinceGrounded = 0f;
		}
		else if (isGrounded && playerState == PlayerState.hanging)
		{
			timeSinceGrounded = 0f;
		}
		else
		{
			timeSinceGrounded += Time.fixedDeltaTime;
		}
		_ = base.transform.position + cCon.center + GetPlayerUpVector() * (0f - cCon.height) * 0.5f + GetPlayerUpVector() * cCon.height;
		if (!forceSoftParent)
		{
			if (Physics.SphereCast(base.transform.position, cCon.radius * 1.1f, -base.transform.up, out var hitInfo2, cCon.height, parentMask) && !noclip)
			{
				if (hitInfo2.collider.tag == "Platform" || hitInfo2.collider.tag == "World")
				{
					softParent.Parent(hitInfo2.transform);
				}
				else
				{
					DebugMenu.UpdateDebugText("playerparent", "Player Parent: N/A");
					Unparent();
				}
			}
			else
			{
				DebugMenu.UpdateDebugText("playerparent", "Player Parent: N/A");
				Unparent();
			}
		}
		if (softParent.GetParent() != null)
		{
			DebugMenu.UpdateDebugText("playerparent", "Player Parent: " + softParent.GetParent().name);
		}
		else
		{
			DebugMenu.UpdateDebugText("playerparent", "Player Parent: NULL");
		}
		if (noclip && !gMan.freecam)
		{
			falling = false;
			softParent.Unparent();
			vel = Vector3.zero;
			if (!gMan.lockPlayerInput)
			{
				vel += GetPlayerUpVector() * (((InputManager.GetButton("Jump").Pressed && (!gMan.lockPlayer || !gMan.lockPlayerInput)) ? 1 : 0) - (((Input.GetKey(KeyCode.F) || InputManager.GetButton("Crouch").Pressed) && !gMan.lockPlayer) ? 1 : 0)) * 10f;
				cCon.enabled = false;
				capsuleCollider.enabled = false;
				if (InputManager.GetButton("Sprint").Pressed)
				{
					moveAxis *= 4f;
					vel.y *= 3f;
				}
				base.transform.position += (moveAxis * 6f + vel) * Time.fixedDeltaTime * 2f;
			}
			curSpeed = sprintSpeed * speedMult;
			SetCameraFov(SettingsManager.settings.playerFOV);
			curFOV = SettingsManager.settings.playerFOV;
			windAudio.volume = 0f;
			DebugMenu.UpdateDebugText("player-position", "Current Player Position: " + base.transform.position);
			DebugMenu.UpdateDebugText("player-controller-velocity", "CVEL: " + cCon.velocity);
			DebugMenu.UpdateDebugText("player-drag", "Current Player Drag: " + curDrag);
			return;
		}
		if (!cCon.enabled)
		{
			cCon.enabled = true;
			capsuleCollider.enabled = true;
		}
		if (IsSprintHeld())
		{
			if (!sprinting)
			{
				OnStartSprinting();
			}
			sprinting = true;
			if (IsGrounded() && vel.magnitude > 0.01f)
			{
				timeSinceSprinting += Time.deltaTime;
			}
		}
		else
		{
			if (sprinting)
			{
				OnStopSprinting();
			}
			sprinting = false;
			timeSinceSprinting = 0f;
		}
		if (curBuffs.GetBuff("forceCrouchIfGrounded") > 0f && IsGrounded() && !IsHanging())
		{
			flag = true;
		}
		if ((crouchPressed || flag) && !gMan.lockPlayer && !gMan.lockPlayerInput && !gMan.freecam && !crouching)
		{
			crouching = true;
			sprinting = false;
			StopCoroutine("ChangeHeight");
			StartCoroutine("ChangeHeight", crouchHeight);
			flag2 = crouching && curBuffs.GetBuff("addJumpBoost") > 0f && IsGrounded(includeCoyoteTime: true) && GetAverageGripStrength() > 1f;
			if (flag2 && isGrounded && timeSinceJumpBoost > 0.3f)
			{
				clipHandler.GetGroup("perk").GetSet("jumpboost-prime").Play(1f, audioChannels[2]);
			}
		}
		if (crouching && !(crouchPressed || flag) && CanUncrouch())
		{
			crouching = false;
			StopCoroutine("ChangeHeight");
			StartCoroutine("ChangeHeight", standingHeight);
		}
		Hand[] array = hands;
		foreach (Hand hand in array)
		{
			if (hand.interactState == InteractType.grab && hand.grabTarget != null)
			{
				float num6 = Vector3.Distance(base.transform.position, hand.grabTarget.transform.position);
				float num7 = hand.grabTarget.holdDistance * 0.5f;
				if (num6 < num7)
				{
					Vector3 vector4 = base.transform.position - hand.grabTarget.transform.position;
					vector4.y = 0f;
					vector4 = vector4.normalized;
					vel += vector4 * (0f - (num6 - num7)) * Time.fixedDeltaTime * 0.5f;
				}
			}
		}
		if (!IsFlying())
		{
			if (!grappled)
			{
				vel += GetPlayerGravityVector() * num3 * Time.fixedDeltaTime;
			}
			else
			{
				vel += GetPlayerGravityVector() * num3 * Time.fixedDeltaTime * averageGrappleInfo.gravityMultiplier;
			}
		}
		if (grappled)
		{
			curDrag *= averageGrappleInfo.frictionMultiplier;
		}
		if (isGrounded)
		{
			if (!isSliding)
			{
				vel.y = Mathf.Max(vel.y, -0.05f);
				curDrag = ((!(moveAxis.magnitude > Mathf.Epsilon)) ? (curDrag * (frictionMultiplier * curFootstep.friction)) : (curDrag * 15f));
			}
		}
		else if (isSwimming)
		{
			curSpeed *= swimControl;
			curDrag *= swimFrictionMultiplier;
		}
		else
		{
			Vector2 vector5 = new Vector2(correctedVelocity.x, correctedVelocity.y);
			curSpeed *= airControl;
			if (!IsHanging() && curBuffs.GetBuff("addAirControl") > 0f)
			{
				Vector3 vector6 = moveAxis;
				if (cConHit != null && hitTime > 0f && Vector3.Dot(vector6, cConHit.normal) < 0f)
				{
					vector6 *= Mathf.Clamp01(Vector3.Dot(vector6, cConHit.normal));
				}
				float value = Vector3.Dot(vector6, correctedVelocity.normalized);
				value = Mathf.Clamp01(value);
				float magnitude = vector5.magnitude;
				vel += vector6 / (1f + magnitude * value * 1.5f) * Time.fixedDeltaTime * curBuffs.GetBuff("addAirControl");
			}
			if (grappled)
			{
				curDrag *= averageGrappleInfo.airbornFrictionMultiplier;
			}
			if (IsHanging() && hitTime > 0f)
			{
				if (sprinting)
				{
					curDrag *= wallfrictionMultiplier;
				}
				else if (crouchPressed && !grappled)
				{
					curDrag *= wallfrictionMultiplier * 30f;
					vel = Vector3.Lerp(vel, Vector3.zero, Time.deltaTime * 5f);
				}
				else
				{
					curDrag *= wallfrictionMultiplier * 3f;
					if (isResting && moveAxis.magnitude < 0.1f)
					{
						curDrag *= 1f + curBuffs.GetBuff("addRestingFriction");
					}
				}
			}
		}
		if (IsHanging() && !IsGrounded() && correctedVelocity.magnitude < 0.3f && Time.time - lastHitSurfaceTime < 0.5f && inputAxis.magnitude < 0.1f)
		{
			if (!isResting)
			{
				isResting = true;
				_OnClimbRest?.Invoke();
			}
		}
		else if (isResting)
		{
			isResting = false;
		}
		if (!IsMoveLocked() && !CommandConsole.IsConsoleVisible())
		{
			camSway = Mathf.Lerp(camSway, 0f, Time.deltaTime * 2f);
			if (isSwimming)
			{
				camSway = Mathf.Lerp(camSway, Mathf.Sin(Time.time * headbobSwimSwayFrequency + headbobSwimSwayOffset) * headbobSwimSwayAmount * 2f * SettingsManager.settings.headbobMultiplier, 1f);
				curFOV = SettingsManager.settings.playerFOV;
			}
			else if (sprinting && IsGrounded(includeCoyoteTime: true) && !isSliding)
			{
				if (isGrounded)
				{
					curSpeed = sprintSpeed * speedMult;
				}
				camSway = Mathf.Lerp(camSway, Mathf.Sin(Time.time * headbobSprintSwayFrequency + headbobSprintSwayOffset) * headbobSprintSwayAmount * 2f * SettingsManager.settings.headbobMultiplier, 1f);
				if (!SettingsManager.settings.disableSprintFov)
				{
					curFOV = sprintFOV;
				}
			}
			else if (crouching && !isSliding)
			{
				curSpeed = crouchSpeed * speedMult;
				curFOV = SettingsManager.settings.playerFOV;
			}
			else
			{
				curFOV = SettingsManager.settings.playerFOV;
			}
			if (moveAxis.magnitude > 0.2f && isGrounded)
			{
				float num8 = headbobLimpSwayCurve.Evaluate(Mathf.Sin(Time.time * headbobLimpFrequency) * 0.5f + 0.5f) * headbobLimpSway * curBuffs.GetBuff("addLimp");
				camSway = Mathf.Lerp(camSway, camSway + num8 * 2f, 2f * Time.deltaTime);
			}
		}
		FootstepAudio(moveAxis, curSpeed);
		for (int j = 0; j < hands.Length; j++)
		{
			if ((bool)hands[j].grabTarget)
			{
				float num9 = 0f;
				if (hands[j].grabTarget.stuck)
				{
					num9 = hands[j].grabTarget.stuckStrength * 0.1f;
				}
				curSpeed = Mathf.Clamp(curSpeed - hands[j].grabTarget.GetRigidbody().mass * 0.1f - num9, 0f, curSpeed);
			}
		}
		Vector3 vector7 = Hang(ref moveAxis, ref curSpeed, ref curDrag);
		curSpeed *= inventory.GetEncumberance();
		if (gMan.lockPlayer || gMan.freecam || gMan.lockPlayerInput)
		{
			moveAxis = Vector3.zero;
		}
		float num10 = ((IsGrounded() && !IsHanging()) ? curBuffs.GetBuff("addGroundedSpeed") : 0f);
		float a = num * ((curBuffs.GetBuff("addSpeed") + 1f + num10) / (1f + curBuffs.GetBuff("addSlow")) / (1f + curBuffs.GetBuff("divideSpeed")));
		a = Mathf.Max(a, 0f);
		if (IsHanging() && !isGrounded)
		{
			a *= num * GetBuffMaxBetweenPlayerAndHands("addHangSpeed") + 1f;
		}
		curSpeed *= num2;
		if (cutsceneMode)
		{
			a = 1f;
		}
		vel += (moveAxis * (curSpeed * a * curFootstep.moveSpeed) + vector7 * 1.5f) * Time.fixedDeltaTime * 0.15f;
		curDrag *= 1f + curBuffs.GetBuff("addDrag");
		float num11 = curDrag * vel.sqrMagnitude;
		Vector3 vector8 = -vel.normalized * num11;
		vel += Vector3.ClampMagnitude(vector8 * Time.fixedDeltaTime, vel.magnitude / 2f);
		if (!canJumpThisFrame)
		{
			timeSinceGrounded = coyoteTime + 0.01f;
		}
		if (!isSwimming && !fly && (((timeSinceGrounded < coyoteTime || playerState == PlayerState.hanging || extraJumpsRemaining > 0 || temporaryExtraJumpsRemaining > 0) && !gMan.lockPlayer && !gMan.freecam && !gMan.lockPlayerInput && canJumpThisFrame) || forceJump))
		{
			if ((InputManager.GetButton("Jump").Pressed && !hasJumped) || forceJump)
			{
				Jump(flag2);
				forceJump = false;
			}
			else if (!InputManager.GetButton("Jump").Pressed)
			{
				hasJumped = false;
			}
		}
		verticalSlide = false;
		float num12 = Vector3.Dot(vel.normalized, hitNormal);
		DebugMenu.UpdateDebugText("hitnormal", "HIT NORMAL: " + hitNormal);
		if (cConHit != null)
		{
			DebugMenu.UpdateDebugText("cconhitnormal", "CCON HIT NORMAL: " + cConHit.normal);
		}
		if (hitTime >= 0f && num12 <= 0f && num4 >= 85f)
		{
			vel = Vector3.ProjectOnPlane(vel, hitNormal);
			verticalSlide = true;
		}
		DebugMenu.UpdateDebugText("verticalSlide", "Vertical Slide: " + verticalSlide);
		DebugMenu.UpdateDebugText("hitdot", "Slide Dot: " + num12);
		DebugMenu.UpdateDebugText("slideangle", "Slide Angle: " + num4);
		cCon.Move(vel * Time.fixedDeltaTime * 175f);
		if (!verticalSlide && isGrounded)
		{
			Vector3 vector9 = cCon.velocity * Time.fixedDeltaTime;
			vel.x = Mathf.Clamp(vel.x, 0f - Mathf.Abs(vector9.x), Mathf.Abs(vector9.x));
			vel.z = Mathf.Clamp(vel.z, 0f - Mathf.Abs(vector9.z), Mathf.Abs(vector9.z));
			vel.y = Mathf.Clamp(vel.y, 0f - Mathf.Abs(vector9.y), Mathf.Abs(vector9.y));
		}
		DebugMenu.UpdateDebugText("player-position", "Current Player Position: " + base.transform.position);
		DebugMenu.UpdateDebugText("player-controller-velocity", "CVEL: " + cCon.velocity);
		DebugMenu.UpdateDebugText("player-drag", "Current Player Drag: " + curDrag);
		if (CL_UIManager.debug && cConHit != null)
		{
			CL_DebugView.draw.Circle(cConHit.point, cConHit.normal, 0.3f);
			CL_DebugView.draw.Arrow(cConHit.point, cConHit.point + cConHit.normal, Color.gray);
			CL_DebugView.draw.Arrow(cConHit.point, cConHit.point + jumpDir, Color.blue);
			CL_DebugView.draw.Arrow(base.transform.position + base.transform.forward, base.transform.position + base.transform.forward + hitNormal, Color.blue);
			CL_DebugView.draw.Arrow(base.transform.position + base.transform.forward, base.transform.position + base.transform.forward + cConHit.normal, Color.green);
			CL_DebugView.draw.Arrow(base.transform.position + base.transform.forward, base.transform.position + base.transform.forward + climbDir, Color.yellow);
			if (IsHanging())
			{
				CL_DebugView.draw.Arrow(cConHit.point, cConHit.point + climbDir, Color.red);
			}
		}
		if (hitTime <= 0f)
		{
			isSliding = false;
		}
		canJumpThisFrame = true;
		WindSound();
		void Unparent()
		{
			if (softParent.IsParented())
			{
				Vector3 deltaWorldVelocity = softParent.GetDeltaWorldVelocity();
				softParent.Unparent();
				float num13 = 1f;
				if (IsHanging())
				{
					num13 *= 0.05f;
				}
				if (!forceSoftParentPreventVelocityTransfer)
				{
					vel += deltaWorldVelocity * 0.005f * num13;
				}
				forceSoftParentPreventVelocityTransfer = false;
			}
		}
	}

	private void OnStopSprinting()
	{
		Hand[] array = hands;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GetViewSway().UnsetCustomParameters();
		}
	}

	private void OnStartSprinting()
	{
	}

	public void ForceJump()
	{
		forceJump = true;
	}

	public void Jump(bool canJumpBoost = false, float mult = 1f)
	{
		bool flag = false;
		bool flag2 = false;
		lastJumpTime = Time.time;
		float num = 0f;
		int num2 = 0;
		bool flag3 = false;
		Hand[] array = hands;
		foreach (Hand hand in array)
		{
			if (hand.GetHandItem() != null && !hand.GetHandItem().AllowJump())
			{
				Debug.Log("We are blocking jump!!");
				flag3 = true;
			}
		}
		if (flag3 && !forceJump)
		{
			return;
		}
		if (playerState == PlayerState.hanging)
		{
			bool flag4 = true;
			array = hands;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].interactState != InteractType.hanging)
				{
					flag4 = false;
				}
			}
			float num3 = 1f;
			if (flag4)
			{
				num3 *= 0.48f;
			}
			num3 /= 1f + curBuffs.GetBuff("divideJumpStrain");
			array = hands;
			foreach (Hand hand2 in array)
			{
				if (hand2.interactState != InteractType.hanging)
				{
					continue;
				}
				if (hand2.handhold != null)
				{
					if (!IsGrounded())
					{
						_OnHandJump?.Invoke(hand2);
					}
					num2++;
					if (hand2.handhold.allowAirbornJump || IsGrounded(includeCoyoteTime: true))
					{
						flag = true;
						hand2.handhold.OnPlayerJump(hand2);
						num += hand2.handhold.GetJumpMult();
						if (hand2.handhold.dropOnJump)
						{
							hand2.gripStrength -= climbJumpDrain / (1f + curBuffs.GetBuff("addGripStrength") + GetBuffOnHand("addGripStrength", hand2.id)) * hand2.handhold.jumpStrainMult * num3;
							StopInteraction(hand2.id, "jump");
						}
					}
					else if (extraJumpsRemaining > 0 || temporaryExtraJumpsRemaining > 0)
					{
						flag = true;
						hand2.handhold.OnPlayerJump(hand2, doubleJump: true);
						flag2 = true;
					}
				}
				else
				{
					StopInteraction(hand2.id, "jump");
					hand2.gripStrength -= climbJumpDrain / (1f + curBuffs.GetBuff("addGripStrength") + GetBuffOnHand("addGripStrength", hand2.id)) * num3;
					flag = true;
				}
			}
		}
		else
		{
			flag = true;
		}
		float a = ((IsGrounded() && !IsHanging()) ? curBuffs.GetBuff("addGroundedJump") : 0f);
		float b = (IsHanging() ? GetBuffMaxBetweenPlayerAndHands("addClimbingJump", onlyHanging: true) : 0f);
		num = ((num2 <= 0) ? 1f : (num / (float)num2));
		float num4 = Mathf.Max(a, b);
		Vector3 vector = (IsHanging() ? climbDir : jumpDir).normalized * (jumpHeight * (1f + curBuffs.GetBuff("addJump") + num4)) * (0f - gravity) * Mathf.Min(inventory.GetEncumberance() * 2f, 1f);
		vector *= num;
		if (cutsceneMode)
		{
			vector = (IsHanging() ? climbDir : jumpDir).normalized * jumpHeight * (0f - gravity) * Mathf.Min(inventory.GetEncumberance() * 2f, 1f);
		}
		if (flag || forceJump)
		{
			bool flag5 = false;
			if (vel.y < 0f)
			{
				vel.y = 0f;
			}
			if (!flag3)
			{
				if (((!(timeSinceGrounded < coyoteTime) && playerState != PlayerState.hanging) || flag2) && !forceJump && (extraJumpsRemaining > 0 || temporaryExtraJumpsRemaining > 0) && !cutsceneMode)
				{
					if (extraJumpsRemaining > 0)
					{
						extraJumpsRemaining--;
					}
					else if (temporaryExtraJumpsRemaining > 0)
					{
						temporaryExtraJumpsRemaining--;
					}
					flag2 = true;
					AddGripStrength(curBuffs.GetBuff("addStaminaAfterExtraJump"));
				}
				else
				{
					AddGripStrength(curBuffs.GetBuff("addStaminaAfterJump"));
					if (canJumpBoost && IsGrounded(includeCoyoteTime: true) && !cutsceneMode)
					{
						timeSinceJumpBoost = 0f;
						AddGripStrength(curBuffs.GetBuff("addStaminaAfterJumpBoost"));
						float buff = curBuffs.GetBuff("addJumpBoost");
						camRoot.ShakeCamera(0.06f);
						if (jumpBoostDecal != null)
						{
							FXManager.DecalHandle handle = FXManager.DecalCreate(FXManager.DecalPriority.Low);
							FXManager.DecalSharedOutput shared = FXManager.DecalSharedData(jumpBoostDecal);
							FXManager.DecalSharedApply(handle, shared);
							FXManager.DecalPointingFrom(handle, cConHit.point, cConHit.normal, base.transform.forward, cConHit.collider.transform);
						}
						if (jumpBoostEffect != null)
						{
							jumpBoostEffect.Play();
						}
						Vector3 vector2 = cam.transform.forward;
						float num5 = Vector3.Angle(GetPlayerUpVector(), vector2);
						if (num5 > 90f)
						{
							vector2 = Vector3.Reflect(vector2, GetPlayerUpVector());
						}
						if (num5 < 45f)
						{
							vector2 *= 0.75f;
						}
						vector += vector2 * buff;
						flag5 = true;
					}
				}
				if (Vector3.Dot(climbDir, GetPlayerUpVector()) > 0f)
				{
					climbDir = GetPlayerUpVector();
				}
				vector.y *= mult;
				vel.y = Mathf.Max(vel.y, vector.y);
				vel.x += vector.x;
				vel.z += vector.z;
				if (flag2)
				{
					clipHandler.GetGroup("perk").GetSet("doublejump").Play(1f);
				}
				else if (flag5)
				{
					clipHandler.GetGroup("perk").GetSet("jumpboost").Play(1f);
				}
				else
				{
					clipHandler.GetGroup("movement").GetSet("jump").Play(1f, audioChannels[2]);
				}
			}
			timeSinceGrounded = coyoteTime;
			hasJumped = true;
			if (IsGrounded())
			{
				_OnGroundedJump?.Invoke();
			}
			if (IsHanging() && !IsGrounded())
			{
				_OnClimbJump?.Invoke();
			}
			isGrounded = false;
			ViewSway.RecieveGlobalImpulse(GetPlayerUpVector() * 0.2f);
			_OnJump?.Invoke();
		}
		if (forceJump)
		{
			forceJump = false;
		}
	}

	private Vector3 Hang(ref Vector3 moveAxis, ref float curSpeed, ref float curDrag)
	{
		float num = (grappled ? GetAverageGrappleInfo().playerGrappleSpeedMod : 1f);
		Vector3 zero = Vector3.zero;
		if (playerState == PlayerState.hanging)
		{
			curSpeed = speed * speedMult;
			float num2 = 1.2f * (1f + curBuffs.GetBuff("addPlayerScale"));
			float num3 = 0f;
			if (!isGrounded)
			{
				climbDir = (hasHit ? MostYFacingPerpendicular(hitNormal) : GetPlayerUpVector());
				if (hasHit && Vector3.Angle(-GetPlayerUpVector(), hitNormal) < 10f)
				{
					climbDir = -GetPlayerUpVector() * 0.15f;
				}
				else if (climbDir != GetPlayerUpVector())
				{
					climbDir += hitNormal * 0.1f;
				}
				DebugMenu.UpdateDebugText("player-climbBool", "Player is Climbing against Surface");
			}
			else
			{
				climbDir = GetPlayerUpVector();
				DebugMenu.UpdateDebugText("player-climbBool", "Player is NOT Climbing against Surface");
			}
			if (Physics.Raycast(cam.transform.position, base.transform.forward, out var _, cCon.radius * 2.5f, jumpMask) && IsHanging())
			{
				moveAxis = base.transform.right * inputAxis.x * 0.5f + inputAxis.y * Vector3.Lerp(cam.transform.forward, -climbDir, 0.3f).normalized;
			}
			else
			{
				moveAxis = base.transform.right * inputAxis.x * 0.5f + inputAxis.y * (cam.transform.forward + climbDir);
			}
			Vector3 vector = Vector3.zero;
			float num4 = GetInteractDistance();
			float num5 = 0f;
			for (int i = 0; i < hands.Length; i++)
			{
				if (hands[i].interactState != InteractType.hanging || IsNullOrDestroyed(hands[i].currentInteract))
				{
					continue;
				}
				Transform holdTarget = hands[i].holdTarget;
				Vector3 vector2 = hands[i].currentInteract.GetGameObject().transform.TransformPoint(hands[i].holdPosition) - base.transform.position;
				float magnitude = vector2.magnitude;
				if (magnitude <= num2)
				{
					vector2 *= 0f;
				}
				else
				{
					vector2 = vector2.normalized * (magnitude - num2);
				}
				if (magnitude > num4 * 1.25f)
				{
					vector2 *= 4f;
					if (magnitude > num4 * 2f)
					{
						StopInteraction(i);
					}
				}
				zero += vector2;
				if (hitNormal != Vector3.zero)
				{
					zero += hitNormal * 0.09f;
				}
				float num6 = Vector3.Dot(cam.transform.forward, GetPlayerUpVector());
				CL_Handhold component = holdTarget.GetComponent<CL_Handhold>();
				if (num6 >= 0f)
				{
					num3 = Mathf.Clamp(num3 + inputAxis.y * 0.015f, 0f, 0.02f);
					if (component != null)
					{
						num3 *= component.GetClimbMult();
					}
					if (num6 > 0.5f)
					{
						num3 *= 1f + num * GetBuffMaxBetweenPlayerAndHands("addClimb", onlyHanging: true) / (1f + GetBuffMaxBetweenPlayerAndHands("addSlow", onlyHanging: true));
					}
				}
				else if (num6 < 0f)
				{
					float t = Mathf.Abs(num6);
					num3 = Mathf.Clamp(num3 + Mathf.Lerp(inputAxis.y, 0f - inputAxis.y, t) * 0.015f, 0f, 0.02f);
					if (component != null)
					{
						num3 *= component.GetClimbMult();
					}
				}
				vel.x += climbDir.x * num3 * Time.fixedDeltaTime;
				vel.y = Mathf.Lerp(vel.y, num3 * climbDir.y, Time.fixedDeltaTime * 8f * Mathf.Clamp(hands[i].holdTime, 0f, 2f) * component.hangVelAdjust);
				vel.z += climbDir.z * num3 * Time.fixedDeltaTime;
				if (component != null)
				{
					vel.y += component.GetGravity() * Time.fixedDeltaTime;
				}
				curDrag = Mathf.Max(curDrag, dragCoefficient * hands[i].dragMult);
				num5 = ((!(component != null)) ? 1f : component.speedMult);
				if (moveAxis.magnitude < 0.05f && crouchPressed)
				{
					vel.y = 0f;
					vel = Vector3.Lerp(vel, Vector3.zero, Time.deltaTime * 5f);
				}
				vector = Vector3.ClampMagnitude(vector + hands[i].GetVelocity(), Mathf.Max(vector.magnitude, hands[i].GetVelocity().magnitude));
			}
			if (timeSinceGrounded > 0.1f)
			{
				zero += vector * -0.06f;
			}
			curSpeed *= 1f + curBuffs.GetBuff("addClimb");
			curSpeed /= 1f + curBuffs.GetBuff("addSlow");
			curSpeed *= num5;
		}
		else
		{
			DebugMenu.UpdateDebugText("player-climbBool", "Player is NOT Climbing");
		}
		return zero;
	}

	public void AddExtraJumpsOneTime(int i)
	{
		temporaryExtraJumpsRemaining += i;
	}

	public void SetSwimming(bool swim)
	{
		if (!swim && isSwimming && InputManager.GetButton("Jump").Pressed && IsHanging())
		{
			Jump();
		}
		isSwimming = swim;
	}

	public void SetHasOxygen(bool oxy)
	{
		hasOxygen = oxy;
	}

	public void SetSpeedMult(float s)
	{
		speedMult = s;
	}

	public void SetFrameSpeedMult(float s)
	{
		frameSpeedMult = s;
	}

	public void ForceSoftParent(Transform t, bool preventVelocityTransfer)
	{
		forceSoftParent = true;
		forceSoftParentPreventVelocityTransfer = preventVelocityTransfer;
		if (softParent.parent != t)
		{
			softParent.Parent(t);
		}
	}

	public Perk AddPerk(Perk perk, int stackAmount = 1, bool firstTime = true)
	{
		if (firstTime)
		{
			foreach (Perk oldPerk in oldPerks)
			{
				if (perk.id == oldPerk.id)
				{
					oldPerk.stackAmount = Mathf.Clamp(oldPerk.stackAmount + stackAmount, 0, oldPerk.stackMax);
				}
			}
		}
		foreach (Perk perk4 in perks)
		{
			if (perk.id == perk4.id)
			{
				perk4.AddStack(stackAmount, firstTime);
				return perk4;
			}
		}
		Perk perk2 = UnityEngine.Object.Instantiate(perk);
		perks.Add(perk2);
		perk2.stackAmount = stackAmount;
		perk2.Initialize(this, firstTime);
		if (perk.guid != Guid.Empty)
		{
			perk2.guid = perk.guid;
		}
		bool flag = false;
		foreach (Perk oldPerk2 in oldPerks)
		{
			if (oldPerk2.guid == perk2.guid)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			Perk perk3 = UnityEngine.Object.Instantiate(perk2);
			perk3.guid = perk2.guid;
			oldPerks.Add(perk3);
		}
		UI_Perk_Icon uI_Perk_Icon = UnityEngine.Object.Instantiate(perkIconAsset, perkIconHolder);
		uI_Perk_Icon.SetPerk(perk2);
		if (perkIcons.ContainsKey(perk2))
		{
			Debug.LogWarning("Player already has perk: " + perk2.id + " when trying to add perk icon. This should not happen.");
			return perk2;
		}
		perkIcons.Add(perk2, uI_Perk_Icon);
		OrganizePerkIconOrder();
		return perk2;
	}

	public List<Perk> GetOldPerks()
	{
		return oldPerks;
	}

	private void OrganizePerkIconOrder()
	{
		perks.Sort((Perk p1, Perk p2) => p1.sortingCategory.CompareTo(p2.sortingCategory));
		for (int num = 0; num < perks.Count; num++)
		{
			Perk key = perks[num];
			if (perkIcons.ContainsKey(key))
			{
				perkIcons[key].transform.SetSiblingIndex(num);
			}
		}
	}

	public List<Perk> RemoveAllPerks(bool forceRemoveAll = true)
	{
		List<Perk> list = new List<Perk>();
		for (int num = perks.Count - 1; num >= 0; num--)
		{
			if (perks[num].removeOnCleanse || forceRemoveAll)
			{
				list.Add(perks[num]);
				perks[num].RemoveFromPlayer();
			}
		}
		if (forceRemoveAll)
		{
			perks.Clear();
		}
		curBuffs.UpdateBuffs();
		OrganizePerkIconOrder();
		return list;
	}

	public void RemovePerk(Perk perk, bool removeAll = true)
	{
		if (perks.Contains(perk) && !removeAll && perk.stackAmount > 1)
		{
			perk.RemoveStack();
		}
		else
		{
			perk.ClearPerkEffects();
			perks.Remove(perk);
			if (perkIcons.ContainsKey(perk))
			{
				if (perkIcons[perk] != null)
				{
					UnityEngine.Object.Destroy(perkIcons[perk].gameObject);
				}
				perkIcons.Remove(perk);
			}
		}
		OrganizePerkIconOrder();
	}

	public void RemovePerk(string perkID, bool removeAll = true)
	{
		Perk perk = null;
		foreach (Perk perk2 in perks)
		{
			if (perk2.id == perkID)
			{
				perk = perk2;
				break;
			}
		}
		if (!(perk == null))
		{
			RemovePerk(perk, removeAll);
		}
	}

	public bool HasPerk(string perkID)
	{
		foreach (Perk perk in perks)
		{
			if (perk.id == perkID)
			{
				return true;
			}
		}
		return false;
	}

	public Perk GetPerk(string perkID)
	{
		foreach (Perk perk in perks)
		{
			if (perk.id == perkID)
			{
				return perk;
			}
		}
		return null;
	}

	public void ClearExtraJumpsRemaining()
	{
		extraJumpsRemaining = 0;
	}

	private void ApplyBuffEffects()
	{
		gMan.uiMan.SetVignette("roids", curBuffs.GetBuff("roided"));
		gMan.uiMan.SetVignetteTarget("goop", curBuffs.GetBuff("gooped_screen"));
		gMan.uiMan.SetVignette("pills", curBuffs.GetBuff("pilled"));
		gMan.uiMan.SetVignette("boost", curBuffs.GetBuff("boosted"));
		gMan.uiMan.SetVignetteTarget("unbound", curBuffs.GetBuff("unbound"));
		gMan.uiMan.SetVignetteTarget("bloodied", curBuffs.GetBuff("bloodied"));
		gMan.uiMan.SetVignette("freezing", curBuffs.GetBuff("freezing"));
		gMan.uiMan.SetVignette("warming", curBuffs.GetBuff("warming") + entityEffects.fire * 2f);
		gMan.uiMan.SetVignette("poisoned", curBuffs.GetBuff("poisoned"));
		camRoot.SetCameraSway(curBuffs.GetBuff("sway"), 1f + curBuffs.GetBuff("swaySpeed"));
	}

	public override bool OnGetBuff(BuffContainer.Buff buff)
	{
		if (buff.id == "food")
		{
			GetPlayer().AddGripStrength(buff.maxAmount);
			return true;
		}
		if (buff.id == "heal")
		{
			GetPlayer().Heal(buff.amount);
			return true;
		}
		return base.OnGetBuff(buff);
	}

	public float GetSlowTimeBuffMult()
	{
		float num = 1f / (1f + curBuffs.GetBuff("slowTime"));
		if (Inventory.IsShowingInventory())
		{
			num *= 1f / (1f + curBuffs.GetBuff("slowTimeInventory"));
		}
		if (InputManager.GetButton("Sprint").Pressed && InputManager.GetButton("Crouch").Pressed)
		{
			num *= 1f / (1f + curBuffs.GetBuff("slowTimeSprintCrouch"));
		}
		if (num >= 0f)
		{
			return num;
		}
		return 1f;
	}

	public float GetCurrentSlowTimeMult()
	{
		return currentBuffSlowTimeMult;
	}

	public float GetCurrentMaxFallDistance()
	{
		float num = Mathf.Clamp01(1f + curBuffs.GetBuff("addGravity"));
		return 50f / (1f + curBuffs.GetBuff("reduceFallDamageDistance")) / num;
	}

	public float GetBuffAverageBetweenPlayerAndHands(string buffID, bool onlyHanging = false)
	{
		float buff = curBuffs.GetBuff(buffID);
		float num = 0f;
		int num2 = 0;
		Hand[] array = hands;
		foreach (Hand hand in array)
		{
			if (!onlyHanging || hand.IsHanging())
			{
				num = curBuffs.GetBuff(buffID + "-hand-" + hand.id);
				num2++;
			}
		}
		num /= (float)num2;
		return buff + num;
	}

	public float GetBuffMaxBetweenPlayerAndHands(string buffID, bool onlyHanging = false)
	{
		float buff = curBuffs.GetBuff(buffID);
		float num = 0f;
		Hand[] array = hands;
		foreach (Hand hand in array)
		{
			if (!onlyHanging || hand.IsHanging())
			{
				num = Mathf.Max(curBuffs.GetBuff(buffID + "-hand-" + hand.id));
			}
		}
		return buff + num;
	}

	public float GetBuffOnHand(string buffID, int handID)
	{
		return curBuffs.GetBuff(buffID + "-hand-" + handID);
	}
}
