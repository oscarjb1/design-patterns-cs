using System;

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipb.flyweight.impl{
    public class PlayItem {

        public Int64 Id{get; set;}
        public string SongName{get; set;}
        private byte[] Song = new byte[1000000];

        public PlayItem(Int64 id, string songName) {
            this.Id = id;
            this.SongName = songName;
        }

        public PlayItem() {
        }

        public override string ToString() {
            return "PlayItem{" + "id=" + Id + ", songName=" + SongName + '}';
        }
    }
}


