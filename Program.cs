using System;

namespace lab3
{

	class MainClass
	{

		static int L=5;
		int[] S;
		int[] U;
		string[] txt;
		//приспособленность случайная
		void SetU(){
			Random rnd = new Random ();
			for(int i = 0;i<S.Length;i++){
				U [i] = rnd.Next(0,300);
				if (i < 32) {
					Console.WriteLine (txt [i] + " U = " + U [i]);
				}
			}
			Console.WriteLine ("================================================================================");
		}
		// Метод восхождения на холм. Поиск в ширину
		void MetodMK(int N){
			bool swap = false;
			int i=0,max = 0, maxS =0, m = 0;
			Random rnd = new Random ();
			int j = rnd.Next (0, S.Length);
			m = j;
			max = U [j];
			maxS = S [j];
			Console.WriteLine ("i= 0 " + "maxS =" + txt[m] + " max =" + max.ToString ());
			while (i < N) {
				for (int f = 0; f < S.Length; f++) {
					if (HamRange (txt [j], txt [f]) == 1) {
						Console.WriteLine ("i= "+i+"|" + txt [f] + " U =" + U [f]);
						if (max < U [f]) {
							max = U [f];
							maxS = S [f];
							m = f;
							swap = true;
						}
					}
				}
				if (swap) {
					Console.WriteLine ("i= " + i + " SWAP " + "maxS = " + txt [m] + " max = " + max.ToString ());
					swap = false;
				} else
					break;
				i = i + 1;
				j = m;

			}
			Console.WriteLine ("END " + "maxS =" + txt[m] + " max =" + max.ToString ());
		}
		//Метод возвращающий Расстоя́ние Хэ́мминга
		int HamRange(string s1,string s2){
			int range = 0;
			for(int i = 0; i<s1.Length;i++){
				if (s1 [i] != s2 [i])
					range++;
			}
			return range;
		}

		//Инициализация ПП
		public void IniS(int n){

			S = new int[(int)Math.Pow(2,n)];
			U = new int[(int)Math.Pow(2,n)];
			txt = new string[(int)Math.Pow(2,n)];
			int x;

			for (int j = 0; j < (int)Math.Pow(2,n); j++) {
				x = j;
				S [j] = j;
				string BI = Convert.ToString (S [j], 2);
				if (BI.Length < n) {
					while (BI.Length != n) {
						BI = String.Concat ('0' + BI);
					}
				}
				txt [j] = BI;
			}

		}
		public static void Main (string[] args)
		{
			MainClass MC = new MainClass();

			MC.IniS(L);
			MC.SetU ();
			MC.MetodMK (10);
		}
	}
}
