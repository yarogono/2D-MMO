using Server.Game.Job;

namespace Server.Game.Room
{
    public class GameRoom : JobSerializer
    {
        public int RoomId { get; set; }

        //Dictionary<int, Player> _players = new Dictionary<int, Player>();

        public void Init()
        {

        }


        // 누군가 주기적으로 호출해줘야 한다
        public void Update()
        {
            Flush();
        }

        //public void EnterGame(GameObject gameObject)
        //{
        //}


        //public void Broadcast(IMessage packet)
        //{
        //    foreach (Player p in _players.Values)
        //    {
        //        p.Session.Send(packet);
        //    }
        //}

        //public void Broadcast(IMessage packet, int exceptPlayerId)
        //{
        //    foreach (Player p in _players.Values)
        //    {
        //        if (p.Id != exceptPlayerId)
        //            p.Session.Send(packet);
        //    }
        //}
    }
}
