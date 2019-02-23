using System;

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipb.flyweight.impl{
    public class PlayItem {

        private Int64 id;
        private string songName;
        private byte[] song = new byte[1000000];

        public PlayItem(Int64 id, string songName) {
            this.id = id;
            this.songName = songName;
        }

        public PlayItem() {
        }

        public string getSongName() {
            return songName;
        }

        public void setSongName(string songName) {
            this.songName = songName;
        }

        public Int64 getId() {
            return id;
        }

        public void setId(Int64 id) {
            this.id = id;
        }

        public override string ToString() {
            return "PlayItem{" + "id=" + id + ", songName=" + songName + '}';
        }
    }
}


