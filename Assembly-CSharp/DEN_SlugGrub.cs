using UnityEngine;

[RequireComponent(typeof(UT_AudioClipHandler))]
public class DEN_SlugGrub : Denizen
{
	public string[] fearTags;

	public float sightDistance = 2f;

	public float barkRate = 1f;

	private float barkTime;

	private float fearTime;

	private float wakeTime;

	public Animator animator;

	private Rigidbody rigid;

	private Item_Object itemObject;

	public override void Start()
	{
		base.Start();
		itemObject = GetComponent<Item_Object>();
		if (Random.value > 0.5f)
		{
			base.transform.localScale = Vector3.Scale(base.transform.localScale, new Vector3(-1f, 1f, 1f));
		}
		barkTime = Random.Range(barkRate * 0.5f, barkRate * 2f);
		clipHandler = GetComponent<UT_AudioClipHandler>();
		rigid = GetComponent<Rigidbody>();
	}

	public override void OnEnable()
	{
		if (itemObject != null && itemObject.itemData.inBag)
		{
			wakeTime = Random.Range(0f, 2.5f);
			animator.SetBool("awake", value: false);
		}
		base.OnEnable();
	}

	public override void Update()
	{
		base.Update();
		Collider[] array = Physics.OverlapSphere(base.transform.position, sightDistance, sight.sightMask);
		if (array.Length != 0)
		{
			for (int i = 0; i < array.Length; i++)
			{
				ObjectTagger component = array[i].GetComponent<ObjectTagger>();
				if (component != null && component.HasTagInList(fearTags))
				{
					if (CL_UIManager.debug)
					{
						CL_DebugView.draw.SphereOutline(base.transform.position, 0.45f, Color.yellow);
					}
					if (fearTime <= 0f)
					{
						wakeTime = Random.Range(0f, 2.5f);
					}
					fearTime = 1f;
				}
			}
		}
		if (fearTime > 0f)
		{
			barkTime -= Time.deltaTime;
			fearTime -= Time.deltaTime;
			if (wakeTime <= 0f)
			{
				animator.SetBool("awake", value: true);
			}
			else
			{
				wakeTime -= Time.deltaTime;
			}
		}
		else
		{
			animator.SetBool("awake", value: false);
		}
		if (itemObject.itemData.inBag)
		{
			if (wakeTime <= 0f)
			{
				animator.SetBool("awake", value: true);
			}
			else
			{
				wakeTime -= Time.deltaTime;
			}
		}
		if (!rigid.isKinematic)
		{
			base.transform.rotation = Quaternion.Euler(0f, base.transform.rotation.eulerAngles.y, 0f);
		}
	}

	public override void MassDrownCheck()
	{
		bool flag = false;
		if (itemObject != null && itemObject.itemData != null)
		{
			flag = itemObject.itemData.InInventory();
		}
		if (!flag)
		{
			base.MassDrownCheck();
		}
	}

	public override void Kill(string type = "", Damageable.DamageInfo info = null)
	{
		base.Kill(type, info);
		if ((type == "player" || (info != null && info.HasTag("player"))) && DEN_Mother.instance != null && Vector3.Distance(DEN_Mother.instance.transform.position, base.transform.position) < 50f)
		{
			DEN_Mother.instance.Enrage();
		}
		Object.Destroy(base.gameObject);
	}
}
