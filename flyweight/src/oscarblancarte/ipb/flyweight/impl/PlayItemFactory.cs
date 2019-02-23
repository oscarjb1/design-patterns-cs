using System.Collections.Generic;
using System; 

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipb.flyweight.impl{
    public class PlayItemFactory {
        public static bool enableFlyweight = true;
        private static readonly Dictionary<String,PlayItem> PLAY_ITEMS = new Dictionary<String,PlayItem>();
        private static Int64 idSequence = 0L;
        public static PlayItem createPlayItem(String songName){
            if(enableFlyweight && PLAY_ITEMS.ContainsKey(songName)){
                return PLAY_ITEMS[songName];
            }else{
                PlayItem playItem = new PlayItem(++idSequence, songName);
                PLAY_ITEMS.Add(songName, playItem);
                return playItem;
            }
        }
    }
}



