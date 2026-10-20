using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ExpandableArray_DataContainer<T> where T : class, ExpandableArray_DataContainer<T>.ugpKkEVXVrrncvZtNdGCABWuPomK, new()
	{
		public interface ugpKkEVXVrrncvZtNdGCABWuPomK : IComparable<T>
		{
			void uubVGqfqCbfoewrHMGXTaBcprmcFA(T P_0);

			bool dIWjplNEJESlibcjxBYtBRAMnmCXA(T P_0);

			void VtbgSzfHQNhrMvKwdnPYMpAtYPHVA();
		}

		public readonly T injector;

		private T[] EMAaaTBSAhTIPOyNGQqTWSXQfTpYA;

		private int LMMKprXEhvRwgIdGqBsQCTgKgqmr;

		private int oEmXkXGdaifHYARvcwbDdDsVuBpDA;

		private int tldTlIyXseLSreNJADJexrIplIjU;

		private int wiswqCZvpJbVqPjoYkQunCByTYjt;

		private bool ToGGbobyamtTSJcvCaFtAZUzTBii;

		public int Count => LMMKprXEhvRwgIdGqBsQCTgKgqmr;

		public int Length => LMMKprXEhvRwgIdGqBsQCTgKgqmr;

		public int MaxLength => oEmXkXGdaifHYARvcwbDdDsVuBpDA;

		public int FreeSpace => oEmXkXGdaifHYARvcwbDdDsVuBpDA - LMMKprXEhvRwgIdGqBsQCTgKgqmr;

		public T this[int index]
		{
			get
			{
				if (index >= LMMKprXEhvRwgIdGqBsQCTgKgqmr)
				{
					throw new IndexOutOfRangeException();
				}
				return EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[index];
			}
		}

		public ExpandableArray_DataContainer(int P_0, bool P_1 = true, int P_2 = 0)
		{
			injector = new T();
			EMAaaTBSAhTIPOyNGQqTWSXQfTpYA = new T[P_0];
			LMMKprXEhvRwgIdGqBsQCTgKgqmr = 0;
			oEmXkXGdaifHYARvcwbDdDsVuBpDA = P_0;
			ToGGbobyamtTSJcvCaFtAZUzTBii = P_1;
			tldTlIyXseLSreNJADJexrIplIjU = P_2;
			for (int i = 0; i < oEmXkXGdaifHYARvcwbDdDsVuBpDA; i++)
			{
				EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[i] = new T();
			}
		}

		public int Inject()
		{
			int result = AddData(injector);
			if (ToGGbobyamtTSJcvCaFtAZUzTBii)
			{
				injector.VtbgSzfHQNhrMvKwdnPYMpAtYPHVA();
			}
			return result;
		}

		public int InjectIfUnique()
		{
			int result = AddIfUnique(injector);
			if (ToGGbobyamtTSJcvCaFtAZUzTBii)
			{
				injector.VtbgSzfHQNhrMvKwdnPYMpAtYPHVA();
			}
			return result;
		}

		public int AddData(T item)
		{
			if (LMMKprXEhvRwgIdGqBsQCTgKgqmr >= oEmXkXGdaifHYARvcwbDdDsVuBpDA)
			{
				if (tldTlIyXseLSreNJADJexrIplIjU <= 0)
				{
					return -1;
				}
				YoxejedkZWtixcFJmLtuhhcUgLvb();
			}
			int lMMKprXEhvRwgIdGqBsQCTgKgqmr = LMMKprXEhvRwgIdGqBsQCTgKgqmr;
			EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[lMMKprXEhvRwgIdGqBsQCTgKgqmr].uubVGqfqCbfoewrHMGXTaBcprmcFA(item);
			LMMKprXEhvRwgIdGqBsQCTgKgqmr = lMMKprXEhvRwgIdGqBsQCTgKgqmr + 1;
			return lMMKprXEhvRwgIdGqBsQCTgKgqmr;
		}

		public int AddIfUnique(T item)
		{
			int num = IndexOfData(item);
			if (num >= 0)
			{
				return num;
			}
			return AddData(item);
		}

		public bool ContainsData(T item)
		{
			for (int i = 0; i < LMMKprXEhvRwgIdGqBsQCTgKgqmr; i++)
			{
				if (EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[i].dIWjplNEJESlibcjxBYtBRAMnmCXA(item))
				{
					return true;
				}
			}
			return false;
		}

		public int IndexOfData(T item)
		{
			for (int i = 0; i < LMMKprXEhvRwgIdGqBsQCTgKgqmr; i++)
			{
				if (EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[i].dIWjplNEJESlibcjxBYtBRAMnmCXA(item))
				{
					return i;
				}
			}
			return -1;
		}

		public void Clear()
		{
			if (ToGGbobyamtTSJcvCaFtAZUzTBii)
			{
				injector.VtbgSzfHQNhrMvKwdnPYMpAtYPHVA();
				for (int i = 0; i < LMMKprXEhvRwgIdGqBsQCTgKgqmr; i++)
				{
					EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[i].VtbgSzfHQNhrMvKwdnPYMpAtYPHVA();
				}
			}
			LMMKprXEhvRwgIdGqBsQCTgKgqmr = 0;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= LMMKprXEhvRwgIdGqBsQCTgKgqmr)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (index == LMMKprXEhvRwgIdGqBsQCTgKgqmr - 1)
			{
				RemoveLast();
				return;
			}
			if (ToGGbobyamtTSJcvCaFtAZUzTBii)
			{
				EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[index].VtbgSzfHQNhrMvKwdnPYMpAtYPHVA();
			}
			for (int i = index; i < LMMKprXEhvRwgIdGqBsQCTgKgqmr - 1; i++)
			{
				EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[i].uubVGqfqCbfoewrHMGXTaBcprmcFA(EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[i + 1]);
			}
			if (ToGGbobyamtTSJcvCaFtAZUzTBii)
			{
				EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[LMMKprXEhvRwgIdGqBsQCTgKgqmr - 1].VtbgSzfHQNhrMvKwdnPYMpAtYPHVA();
			}
			LMMKprXEhvRwgIdGqBsQCTgKgqmr--;
		}

		public void RemoveLast()
		{
			if (LMMKprXEhvRwgIdGqBsQCTgKgqmr != 0)
			{
				if (ToGGbobyamtTSJcvCaFtAZUzTBii)
				{
					EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[LMMKprXEhvRwgIdGqBsQCTgKgqmr - 1].VtbgSzfHQNhrMvKwdnPYMpAtYPHVA();
				}
				LMMKprXEhvRwgIdGqBsQCTgKgqmr--;
			}
		}

		public void Resize(int size)
		{
			if (size <= 0)
			{
				throw new Exception("Size must be greater than 0.");
			}
			if (size == oEmXkXGdaifHYARvcwbDdDsVuBpDA)
			{
				return;
			}
			T[] array = new T[size];
			int num = Math.Min(size, oEmXkXGdaifHYARvcwbDdDsVuBpDA);
			for (int i = 0; i < num; i++)
			{
				array[i] = EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[i];
			}
			if (size > oEmXkXGdaifHYARvcwbDdDsVuBpDA)
			{
				for (int j = num; j < size; j++)
				{
					array[j] = new T();
				}
			}
			else if (LMMKprXEhvRwgIdGqBsQCTgKgqmr > size)
			{
				LMMKprXEhvRwgIdGqBsQCTgKgqmr = size;
			}
			oEmXkXGdaifHYARvcwbDdDsVuBpDA = size;
			EMAaaTBSAhTIPOyNGQqTWSXQfTpYA = array;
		}

		public void SortAscending()
		{
			if (LMMKprXEhvRwgIdGqBsQCTgKgqmr == 0)
			{
				return;
			}
			for (int i = 0; i < LMMKprXEhvRwgIdGqBsQCTgKgqmr - 1; i++)
			{
				for (int j = i + 1; j < LMMKprXEhvRwgIdGqBsQCTgKgqmr; j++)
				{
					if (EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[j].CompareTo(EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[i]) < 0)
					{
						T val = EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[i];
						EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[i] = EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[j];
						EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[j] = val;
					}
				}
			}
		}

		public void SortDescending()
		{
			if (LMMKprXEhvRwgIdGqBsQCTgKgqmr == 0)
			{
				return;
			}
			for (int i = 0; i < LMMKprXEhvRwgIdGqBsQCTgKgqmr - 1; i++)
			{
				for (int j = i + 1; j < LMMKprXEhvRwgIdGqBsQCTgKgqmr; j++)
				{
					if (EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[j].CompareTo(EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[i]) > 0)
					{
						T val = EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[i];
						EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[i] = EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[j];
						EMAaaTBSAhTIPOyNGQqTWSXQfTpYA[j] = val;
					}
				}
			}
		}

		private void YoxejedkZWtixcFJmLtuhhcUgLvb()
		{
			wiswqCZvpJbVqPjoYkQunCByTYjt++;
			Resize(oEmXkXGdaifHYARvcwbDdDsVuBpDA + wiswqCZvpJbVqPjoYkQunCByTYjt * tldTlIyXseLSreNJADJexrIplIjU);
		}
	}
}
