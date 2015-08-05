using System.Threading;
using SharksGame;

namespace SharkGame
{
    class SharkGameMain
    {
        static void Main()
        {
            Intro.Menu();
            Thread thread1 = new Thread(Music.Play);
            Thread thread2 = new Thread(Drawer.Draw);
            thread1.Start();
            thread2.Start();           
        }
    }
}
