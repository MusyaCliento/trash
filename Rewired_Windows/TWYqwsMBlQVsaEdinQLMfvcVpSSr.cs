using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal abstract class TWYqwsMBlQVsaEdinQLMfvcVpSSr : IDisposable
{
	[CompilerGenerated]
	private EventHandler<EventArgs> m_LNOXVVjoEwannfpaHAeZJvlqqKAIb;

	[CompilerGenerated]
	private EventHandler<EventArgs> m_YnDIsjgiRrDEFeKGTbaqHgrQhjwVA;

	[CompilerGenerated]
	private bool orQkcwHHnFRKHgmNNuLiVklbGkER;

	public bool FORjLXMlwFwTRIUXMOVHHOFmLmZt
	{
		[CompilerGenerated]
		get
		{
			return orQkcwHHnFRKHgmNNuLiVklbGkER;
		}
		[CompilerGenerated]
		private set
		{
			orQkcwHHnFRKHgmNNuLiVklbGkER = flag;
		}
	}

	public event EventHandler<EventArgs> LNOXVVjoEwannfpaHAeZJvlqqKAIb
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_LNOXVVjoEwannfpaHAeZJvlqqKAIb;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_LNOXVVjoEwannfpaHAeZJvlqqKAIb, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_LNOXVVjoEwannfpaHAeZJvlqqKAIb;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_LNOXVVjoEwannfpaHAeZJvlqqKAIb, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<EventArgs> YnDIsjgiRrDEFeKGTbaqHgrQhjwVA
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_YnDIsjgiRrDEFeKGTbaqHgrQhjwVA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_YnDIsjgiRrDEFeKGTbaqHgrQhjwVA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_YnDIsjgiRrDEFeKGTbaqHgrQhjwVA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_YnDIsjgiRrDEFeKGTbaqHgrQhjwVA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	protected virtual void PGrCqUEaYUwVfIRdGNtlnKlrRHmM()
	{
		try
		{
			kGVuhwTDYHXKAqNyDOvZaFMUBtIA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	public void Dispose()
	{
		kGVuhwTDYHXKAqNyDOvZaFMUBtIA(true);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void kGVuhwTDYHXKAqNyDOvZaFMUBtIA(bool P_0)
	{
		if (!FORjLXMlwFwTRIUXMOVHHOFmLmZt)
		{
			this.LNOXVVjoEwannfpaHAeZJvlqqKAIb?.Invoke(this, EventArgs.Empty);
			bWakYnApdHeERApZwrJaQZSJbvon(P_0);
			GC.SuppressFinalize(this);
			FORjLXMlwFwTRIUXMOVHHOFmLmZt = true;
			this.YnDIsjgiRrDEFeKGTbaqHgrQhjwVA?.Invoke(this, EventArgs.Empty);
		}
	}

	protected abstract void bWakYnApdHeERApZwrJaQZSJbvon(bool P_0);
}
