using oscarblancarte.ipb.flyweight.impl;
using System;
using System.Collections.Generic;
using System.Runtime.Loader;
using System.Diagnostics;

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipb.flyweight{
    public class FlyweightMain {

        private static readonly string[] SongNames = new string[1000];
        private static readonly string[] PlayListNames = new string[4100000];
        private static readonly List<PlayList> PlayLists = new List<PlayList>();

        static void Main(string[] args) {
            Console.WriteLine(""
                + "Playlist creation process started, this process can be\n"
                + "very delayed due to the large amount of objects that \n"
                + "will be created, please wait a moment until you \n"
                + "are notified that the process has finished.");

            Process currentProc = Process.GetCurrentProcess();
            long usedMemory = currentProc.PrivateMemorySize64;
            Console.WriteLine("statMemory > " + (usedMemory/1000000));
            PlayItemFactory.EnableFlyweight = true;
            InitArrays();
            CreateRandonPlayList();

            Console.WriteLine("total playlist > " + PlayLists.Count);
            
            long memoryUsed = currentProc.PrivateMemorySize64;
            Console.WriteLine("Memory Used => " + (memoryUsed / 1000000));
        }

        private static void CreateRandonPlayList() {
            Random random = new Random();
            int p = 0;
            for (int c = 0; c < PlayListNames.Length; c++) {
                PlayList playList = new PlayList(PlayListNames[c]);
                for (int i = 0; i < 10; i++) {
                    int song = random.Next(SongNames.Length);
                    playList.addPlayItem(SongNames[song]);
                }
                PlayLists.Add(playList);
                if(c!=0 && (c+1)%(PlayListNames.Length/10)==0){
                    p+=10;
                    Console.WriteLine("Completed "+ p +"%");
                    Console.WriteLine("Lists created " + PlayLists.Count);
                }
            }
        }

        private static void InitArrays() {
            for (int c = 0; c < SongNames.Length; c++) {
                SongNames[c] = "Song " + (c + 1);
            }

            for (int c = 0; c < PlayListNames.Length; c++) {
                PlayListNames[c] = "PlayList " + (c + 1);
            }
        }
    }
}


