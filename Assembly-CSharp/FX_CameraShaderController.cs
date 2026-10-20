using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

[ExecuteInEditMode]
public class FX_CameraShaderController : MonoBehaviour
{
	[HideInInspector]
	public Camera cam;

	public bool useCameraFX;

	public bool useDepthTexture;

	public bool renderWireframes;

	public bool renderPhysicsMeshes;

	public bool renderBeams;

	public bool controlBloom;

	private CameraClearFlags prevClearFlags;

	public Material mat;

	private Collider[] colliders;

	private Dictionary<Mesh, Mesh> downloadedMeshes = new Dictionary<Mesh, Mesh>();

	private Mesh boxMesh;

	private Mesh capsuleBodyMesh;

	private Mesh capsuleCapMesh;

	private bool? postprocessingEnabled;

	public bool respectPostprocessSetting;

	private void Start()
	{
		if (cam == null)
		{
			cam = base.gameObject.GetComponent<Camera>();
		}
		RefreshDepthTexture();
		if (Application.isPlaying)
		{
			SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(RefreshDepthTexture));
		}
	}

	private void OnDestroy()
	{
		if (Application.isPlaying)
		{
			SettingsManager._OnRefreshAllSettings = (Action)Delegate.Remove(SettingsManager._OnRefreshAllSettings, new Action(RefreshDepthTexture));
		}
	}

	private void OnValidate()
	{
		if (cam == null)
		{
			cam = base.gameObject.GetComponent<Camera>();
		}
		RefreshDepthTexture();
	}

	private void RefreshDepthTexture()
	{
		if (Application.isPlaying && SettingsManager.settings != null && SettingsManager.settings.debugCamDepthDisable)
		{
			cam.depthTextureMode = DepthTextureMode.None;
		}
		else if (useDepthTexture)
		{
			cam.depthTextureMode = DepthTextureMode.Depth;
		}
		else
		{
			cam.depthTextureMode = DepthTextureMode.None;
		}
	}

	private bool IsUsingDepthTexture()
	{
		if (cam == null)
		{
			cam = base.gameObject.GetComponent<Camera>();
		}
		return cam.depthTextureMode == DepthTextureMode.Depth;
	}

	private void OnEnable()
	{
		if (CL_GameManager.gMan != null && CL_GameManager.gMan.fxMan != null)
		{
			CL_GameManager.gMan.fxMan.enabledCameras.Add(this);
		}
	}

	private void OnDisable()
	{
		if (CL_GameManager.gMan != null && CL_GameManager.gMan.fxMan != null)
		{
			CL_GameManager.gMan.fxMan.enabledCameras.Remove(this);
		}
	}

	private void OnPreRender()
	{
		if (useCameraFX)
		{
			FXManager.CameraFX(cam);
		}
		if (renderWireframes)
		{
			GL.wireframe = true;
			prevClearFlags = cam.clearFlags;
			cam.clearFlags = CameraClearFlags.Color;
		}
	}

	private void OnPostRender()
	{
		if (renderWireframes)
		{
			GL.wireframe = false;
			cam.clearFlags = prevClearFlags;
		}
	}

	private void Update()
	{
		bool flag = true;
		if (SettingsManager.settings != null)
		{
			flag = SettingsManager.settings.postprocessing;
		}
		if (respectPostprocessSetting && postprocessingEnabled != flag && Application.isPlaying)
		{
			CRTEffect component = GetComponent<CRTEffect>();
			if (component != null)
			{
				component.enabled = flag;
			}
			PostProcessVolume component2 = GetComponent<PostProcessVolume>();
			if (component2 != null)
			{
				foreach (PostProcessEffectSettings setting in component2.profile.settings)
				{
					if (setting.name.Contains("bloom", StringComparison.OrdinalIgnoreCase) && controlBloom)
					{
						setting.enabled.value = flag;
					}
				}
			}
			postprocessingEnabled = flag;
		}
		if (!renderPhysicsMeshes)
		{
			return;
		}
		GL.wireframe = true;
		colliders = UnityEngine.Object.FindObjectsOfType<Collider>(includeInactive: false);
		Collider[] array = colliders;
		foreach (Collider collider in array)
		{
			Matrix4x4 localToWorldMatrix = collider.transform.localToWorldMatrix;
			if (collider is MeshCollider { sharedMesh: var sharedMesh } meshCollider)
			{
				if (sharedMesh.GetNativeIndexBufferPtr() == IntPtr.Zero)
				{
					continue;
				}
				if (!downloadedMeshes.TryGetValue(meshCollider.sharedMesh, out var value))
				{
					GraphicsBuffer indexBuffer = sharedMesh.GetIndexBuffer();
					NativeArray<ushort> output = new NativeArray<ushort>(indexBuffer.count, Allocator.Persistent);
					AsyncGPUReadback.RequestIntoNativeArray(ref output, indexBuffer).WaitForCompletion();
					value = new Mesh();
					int vertexAttributeStream = sharedMesh.GetVertexAttributeStream(VertexAttribute.Position);
					int vertexAttributeOffset = sharedMesh.GetVertexAttributeOffset(VertexAttribute.Position);
					GraphicsBuffer vertexBuffer = sharedMesh.GetVertexBuffer(vertexAttributeStream);
					NativeArray<byte> output2 = new NativeArray<byte>(vertexBuffer.count * vertexBuffer.stride, Allocator.Persistent);
					AsyncGPUReadback.RequestIntoNativeArray(ref output2, vertexBuffer).WaitForCompletion();
					Vector3[] array2 = new Vector3[vertexBuffer.count];
					for (int j = 0; j < vertexBuffer.count; j++)
					{
						array2[j] = output2.ReinterpretLoad<Vector3>(j * vertexBuffer.stride + vertexAttributeOffset);
					}
					List<int> list = new List<int>(output.Length * 2);
					for (int k = 0; k < output.Length; k += 3)
					{
						list.Add(output[k]);
						list.Add(output[k + 1]);
						list.Add(output[k + 1]);
						list.Add(output[k + 2]);
						list.Add(output[k + 2]);
						list.Add(output[k]);
					}
					value.vertices = array2;
					value.SetIndices(list, MeshTopology.Lines, 0);
					output.Dispose();
					output2.Dispose();
					downloadedMeshes[sharedMesh] = value;
				}
				Graphics.DrawMesh(value, localToWorldMatrix, mat, 0, cam);
			}
			else if (collider is BoxCollider boxCollider)
			{
				if (boxMesh == null)
				{
					float num = 0.5f;
					boxMesh = new Mesh();
					boxMesh.vertices = new Vector3[8]
					{
						new Vector3(num, num, num),
						new Vector3(0f - num, num, num),
						new Vector3(0f - num, num, 0f - num),
						new Vector3(num, num, 0f - num),
						new Vector3(num, 0f - num, num),
						new Vector3(0f - num, 0f - num, num),
						new Vector3(0f - num, 0f - num, 0f - num),
						new Vector3(num, 0f - num, 0f - num)
					};
					int[] indices = new int[24]
					{
						0, 1, 1, 2, 2, 3, 3, 0, 0, 4,
						1, 5, 2, 6, 3, 7, 4, 5, 5, 6,
						6, 7, 7, 4
					};
					boxMesh.SetIndices(indices, MeshTopology.Lines, 0, calculateBounds: true);
				}
				Vector3 size = boxCollider.size;
				localToWorldMatrix.m00 *= size.x;
				localToWorldMatrix.m10 *= size.x;
				localToWorldMatrix.m20 *= size.x;
				localToWorldMatrix.m01 *= size.y;
				localToWorldMatrix.m11 *= size.y;
				localToWorldMatrix.m21 *= size.y;
				localToWorldMatrix.m02 *= size.z;
				localToWorldMatrix.m12 *= size.z;
				localToWorldMatrix.m22 *= size.z;
				Vector3 vector = Matrix4x4.TRS(Vector3.zero, boxCollider.transform.rotation, boxCollider.transform.lossyScale).MultiplyPoint(boxCollider.center);
				localToWorldMatrix.m03 += vector.x;
				localToWorldMatrix.m13 += vector.y;
				localToWorldMatrix.m23 += vector.z;
				Graphics.DrawMesh(boxMesh, localToWorldMatrix, mat, 0, cam);
			}
			else if (!(collider is SphereCollider))
			{
				_ = collider is CapsuleCollider;
			}
		}
		GL.wireframe = false;
	}
}
