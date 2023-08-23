using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Except
{
	class PlayerName{
        public PlayerName(string newName){
            if(newName == ""){
                throw new ArgumentException("名前が空です！");
            }
            if(newName.Length > 10){
                throw new ArgumentException("名前が長すぎます！10文字以内に収めてください。");
            }
            this.Name = newName;
        }

        public readonly string Name;
    }
	class Program
	{
		static void Main()
		{
			PlayerName newPlayerName2 = new PlayerName("");
			try
			{
				PlayerName newPlayerName = new PlayerName("");
			}
			catch (ArgumentException e)
			{
				Console.WriteLine("PlayerNameの作成中にエラーが発生しました: "+e.Message);
			}
		}
	}
}