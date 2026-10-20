using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;

internal class nmpBQAovYKAFTjYpVLxEGKXmVudz
{
	private byte DbMmohRTvFLQulSfFJFSACatwIWJ;

	private byte BhaLCkoyWrHGrVilAjOcdBePewsMA;

	private byte jHjgFesmmJRNZXclcxYtrljmCWNL;

	[CompilerGenerated]
	private Action m_MLtUdFrKUcdYvCKPAcoFdFnKMjWRA;

	public float gxJCEupKQiTeAkVzrtpTDcOnkNHK
	{
		get
		{
			return (float)(int)DbMmohRTvFLQulSfFJFSACatwIWJ / 255f;
		}
		set
		{
			bEzAGzsHHfekaYwhxhcDonjBuqcg = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public float jjyHPxghAMhDboCnrydFOAVTYroP
	{
		get
		{
			return (float)(int)BhaLCkoyWrHGrVilAjOcdBePewsMA / 255f;
		}
		set
		{
			hZXJuNriHzKJCDxVdGLgjNrguVQp = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public float DgsukjedRAdkEjThvNBMDeJoXbZhA
	{
		get
		{
			return (float)(int)jHjgFesmmJRNZXclcxYtrljmCWNL / 255f;
		}
		set
		{
			BwttozAvbTHzdAzaYaOeFdxCDjiY = (byte)MathTools.Clamp((int)(num * 255f), 0, 255);
		}
	}

	public byte bEzAGzsHHfekaYwhxhcDonjBuqcg
	{
		get
		{
			return DbMmohRTvFLQulSfFJFSACatwIWJ;
		}
		set
		{
			DbMmohRTvFLQulSfFJFSACatwIWJ = dbMmohRTvFLQulSfFJFSACatwIWJ;
			if (this.MLtUdFrKUcdYvCKPAcoFdFnKMjWRA != null)
			{
				this.MLtUdFrKUcdYvCKPAcoFdFnKMjWRA();
			}
		}
	}

	public byte hZXJuNriHzKJCDxVdGLgjNrguVQp
	{
		get
		{
			return BhaLCkoyWrHGrVilAjOcdBePewsMA;
		}
		set
		{
			BhaLCkoyWrHGrVilAjOcdBePewsMA = bhaLCkoyWrHGrVilAjOcdBePewsMA;
			if (this.MLtUdFrKUcdYvCKPAcoFdFnKMjWRA != null)
			{
				this.MLtUdFrKUcdYvCKPAcoFdFnKMjWRA();
			}
		}
	}

	public byte BwttozAvbTHzdAzaYaOeFdxCDjiY
	{
		get
		{
			return jHjgFesmmJRNZXclcxYtrljmCWNL;
		}
		set
		{
			jHjgFesmmJRNZXclcxYtrljmCWNL = b;
			if (this.MLtUdFrKUcdYvCKPAcoFdFnKMjWRA != null)
			{
				this.MLtUdFrKUcdYvCKPAcoFdFnKMjWRA();
			}
		}
	}

	public event Action MLtUdFrKUcdYvCKPAcoFdFnKMjWRA
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_MLtUdFrKUcdYvCKPAcoFdFnKMjWRA;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_MLtUdFrKUcdYvCKPAcoFdFnKMjWRA, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_MLtUdFrKUcdYvCKPAcoFdFnKMjWRA;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_MLtUdFrKUcdYvCKPAcoFdFnKMjWRA, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public nmpBQAovYKAFTjYpVLxEGKXmVudz()
	{
	}

	public nmpBQAovYKAFTjYpVLxEGKXmVudz(byte P_0, byte P_1, byte P_2)
	{
		DbMmohRTvFLQulSfFJFSACatwIWJ = P_0;
		BhaLCkoyWrHGrVilAjOcdBePewsMA = P_1;
		jHjgFesmmJRNZXclcxYtrljmCWNL = P_2;
	}
}
