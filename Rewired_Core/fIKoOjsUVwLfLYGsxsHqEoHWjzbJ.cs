using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class fIKoOjsUVwLfLYGsxsHqEoHWjzbJ
{
	private class tPvGlGDeAzuVSBVmxlLPEvmEzHFDc
	{
		private readonly AList<IControllerTemplate> EhEqeQOUdQCaMOzaDdLwrMhoIAwd;

		private IList YPWzrVUJZPcUJIBNUfObnqjDdIVz;

		private IList GsqclNpmdGsDaIgeJiPnMZuYbmLy;

		public readonly Type oUDaFpcjuNIvaPtdfWdjympSenjbA;

		public tPvGlGDeAzuVSBVmxlLPEvmEzHFDc(Type P_0)
		{
			oUDaFpcjuNIvaPtdfWdjympSenjbA = P_0;
			EhEqeQOUdQCaMOzaDdLwrMhoIAwd = new AList<IControllerTemplate>();
		}

		public IList<_0001> bEMXjEYklpiLjDEUurJGtAXIebgO<_0001>() where _0001 : IControllerTemplate
		{
			if (YPWzrVUJZPcUJIBNUfObnqjDdIVz == null)
			{
				WMwPScQStCANCAdKQHzKRvxloxKJ<_0001>();
			}
			return GsqclNpmdGsDaIgeJiPnMZuYbmLy as IList<_0001>;
		}

		public void HubSJvQapcFvYUwgOvOjkwMznUHP(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				EhEqeQOUdQCaMOzaDdLwrMhoIAwd.Add(P_0);
				if (YPWzrVUJZPcUJIBNUfObnqjDdIVz != null)
				{
					YPWzrVUJZPcUJIBNUfObnqjDdIVz.Add(P_0);
				}
			}
		}

		public void tYbBsWASlJpxTxZcFszHnSxYUwLf(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				EhEqeQOUdQCaMOzaDdLwrMhoIAwd.Remove(P_0);
				if (YPWzrVUJZPcUJIBNUfObnqjDdIVz != null)
				{
					YPWzrVUJZPcUJIBNUfObnqjDdIVz.Remove(P_0);
				}
			}
		}

		private void WMwPScQStCANCAdKQHzKRvxloxKJ<_0001>() where _0001 : IControllerTemplate
		{
			YPWzrVUJZPcUJIBNUfObnqjDdIVz = new AList<_0001>();
			GsqclNpmdGsDaIgeJiPnMZuYbmLy = new ReadOnlyCollection<_0001>((AList<_0001>)YPWzrVUJZPcUJIBNUfObnqjDdIVz);
			for (int i = 0; i < EhEqeQOUdQCaMOzaDdLwrMhoIAwd._count; i++)
			{
				YPWzrVUJZPcUJIBNUfObnqjDdIVz.Add(EhEqeQOUdQCaMOzaDdLwrMhoIAwd._items[i]);
			}
		}
	}

	private readonly AList<tPvGlGDeAzuVSBVmxlLPEvmEzHFDc> cRuASRPqYaKJeLLmkCcsGcOOujvrA;

	private readonly Type[] WYpSvqfTIWTphZwLTbQnVJALWjJm;

	private readonly Type[] ZxXZUEmuaHQkpWtikBOZbxawovnI;

	private readonly int XivNOqPdxrSQzLkdywErnncgoyFs;

	public fIKoOjsUVwLfLYGsxsHqEoHWjzbJ(Type[] P_0, Type[] P_1)
	{
		if (P_0.Length != P_1.Length)
		{
			throw new Exception("Controller template types and controller template interface types array lengths do not match.");
		}
		WYpSvqfTIWTphZwLTbQnVJALWjJm = P_0;
		ZxXZUEmuaHQkpWtikBOZbxawovnI = P_1;
		XivNOqPdxrSQzLkdywErnncgoyFs = WYpSvqfTIWTphZwLTbQnVJALWjJm.Length;
		cRuASRPqYaKJeLLmkCcsGcOOujvrA = new AList<tPvGlGDeAzuVSBVmxlLPEvmEzHFDc>();
		for (int i = 0; i < XivNOqPdxrSQzLkdywErnncgoyFs; i++)
		{
			cRuASRPqYaKJeLLmkCcsGcOOujvrA.Add(new tPvGlGDeAzuVSBVmxlLPEvmEzHFDc(ZxXZUEmuaHQkpWtikBOZbxawovnI[i]));
		}
	}

	public void LPYvDZQlHJmSBLNPWIwEIpLEAtRv(Controller P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		int templateCount = P_0.templateCount;
		for (int i = 0; i < templateCount; i++)
		{
			IControllerTemplate controllerTemplate = P_0.Templates[i];
			if (controllerTemplate == null)
			{
				Logger.LogError("Template was null.");
				continue;
			}
			Type type = IJQJwoDIHOlygAApQLDIVYEkpBOr(controllerTemplate.GetType());
			if (type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				lfVDZRABLyhMZHQjeoydtxSOrcoQc(type)?.HubSJvQapcFvYUwgOvOjkwMznUHP(controllerTemplate);
			}
		}
	}

	public void cKhLpzZdxbLRWdRHngLGhLGhgriC(Controller P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		int templateCount = P_0.templateCount;
		for (int i = 0; i < templateCount; i++)
		{
			IControllerTemplate controllerTemplate = P_0.Templates[i];
			if (controllerTemplate == null)
			{
				Logger.LogError("Template was null.");
				continue;
			}
			Type type = IJQJwoDIHOlygAApQLDIVYEkpBOr(controllerTemplate.GetType());
			if (type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				lfVDZRABLyhMZHQjeoydtxSOrcoQc(type)?.tYbBsWASlJpxTxZcFszHnSxYUwLf(controllerTemplate);
			}
		}
	}

	public IList<_0001> pUbgQJGJJLcmIloEyGrUBDcSjNAY<_0001>() where _0001 : IControllerTemplate
	{
		Type typeFromHandle = typeof(_0001);
		for (int i = 0; i < cRuASRPqYaKJeLLmkCcsGcOOujvrA._count; i++)
		{
			tPvGlGDeAzuVSBVmxlLPEvmEzHFDc tPvGlGDeAzuVSBVmxlLPEvmEzHFDc2 = cRuASRPqYaKJeLLmkCcsGcOOujvrA._items[i];
			if ((object)tPvGlGDeAzuVSBVmxlLPEvmEzHFDc2.oUDaFpcjuNIvaPtdfWdjympSenjbA == typeFromHandle)
			{
				return tPvGlGDeAzuVSBVmxlLPEvmEzHFDc2.bEMXjEYklpiLjDEUurJGtAXIebgO<_0001>();
			}
		}
		string text = "";
		for (int j = 0; j < ZxXZUEmuaHQkpWtikBOZbxawovnI.Length; j++)
		{
			text += ZxXZUEmuaHQkpWtikBOZbxawovnI[j].Name;
			if (j != ZxXZUEmuaHQkpWtikBOZbxawovnI.Length - 1)
			{
				text += "\n";
			}
		}
		Logger.LogError("Invalid Controller Template type \"" + typeFromHandle.Name + "\". Only the following Controller Template interface types are allowed:\n" + text);
		return EmptyObjects<_0001>.EmptyReadOnlyIListT;
	}

	private tPvGlGDeAzuVSBVmxlLPEvmEzHFDc lfVDZRABLyhMZHQjeoydtxSOrcoQc(Type P_0)
	{
		for (int i = 0; i < cRuASRPqYaKJeLLmkCcsGcOOujvrA._count; i++)
		{
			if ((object)P_0 == cRuASRPqYaKJeLLmkCcsGcOOujvrA._items[i].oUDaFpcjuNIvaPtdfWdjympSenjbA)
			{
				return cRuASRPqYaKJeLLmkCcsGcOOujvrA._items[i];
			}
		}
		return null;
	}

	private Type IJQJwoDIHOlygAApQLDIVYEkpBOr(Type P_0)
	{
		for (int i = 0; i < XivNOqPdxrSQzLkdywErnncgoyFs; i++)
		{
			if ((object)WYpSvqfTIWTphZwLTbQnVJALWjJm[i] == P_0)
			{
				return ZxXZUEmuaHQkpWtikBOZbxawovnI[i];
			}
		}
		return null;
	}
}
