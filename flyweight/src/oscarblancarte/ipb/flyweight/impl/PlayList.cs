using System.Collections.Generic;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipb.flyweight.impl{
    public class PlayList {

        public string PlayListName{get; set;}
        private List<PlayItem> PlayItems = new List<PlayItem>();

        public PlayList(string playListName) {
            this.PlayListName = playListName;
        }

       

        public List<PlayItem> getPlayItems() {
            return PlayItems;
        }

        public void setPlayItems(List<PlayItem> playItems) {
            this.PlayItems = playItems;
        }

        public void addPlayItem(string songName) {
            PlayItems.Add(PlayItemFactory.createPlayItem(songName));
        }

        public void printList() {
            string output = "\nPlayList > " + PlayListName;
            foreach (PlayItem playItem in PlayItems) {
                output = output + "\n\t" + playItem.ToString();
            }
            Console.WriteLine(output);
        }
    }
}


