using System.Collections.Generic;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipb.flyweight.impl{
    public class PlayList {

        private string playListName;
        private List<PlayItem> playItems = new List<PlayItem>();

        public PlayList(string playListName) {
            this.playListName = playListName;
        }

        public string getPlayListName() {
            return playListName;
        }

        public void setPlayListName(string playListName) {
            this.playListName = playListName;
        }

        public List<PlayItem> getPlayItems() {
            return playItems;
        }

        public void setPlayItems(List<PlayItem> playItems) {
            this.playItems = playItems;
        }

        public void addPlayItem(string songName) {
            playItems.Add(PlayItemFactory.createPlayItem(songName));
        }

        public void printList() {
            string output = "\nPlayList > " + playListName;
            foreach (PlayItem playItem in playItems) {
                output = output + "\n\t" + playItem.ToString();
            }
            Console.WriteLine(output);
        }
    }
}


