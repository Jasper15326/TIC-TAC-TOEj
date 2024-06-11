using System.Collections.Generic;

namespace TicTacToe
{
    public abstract class User
    {
        public string UserId { get; set; }
        protected internal string UserPassword { get; set; }

        public User(string id, string pass)
        {
            this.UserId = id;
            this.UserPassword = pass;
        }

        public bool VerifyLogin(string id, string password) =>
            id == UserId && password == UserPassword;

        public abstract void UpdatePassword(string newPassword);
    }

    public class Administrator : User
    {
        public string AdminName { get; set; }
        public List<Player> Players { get; private set; }

        public Administrator(string adminName, string adminId, string password) : base(adminId, password)
        {
            this.AdminName = adminName;
            Players = new List<Player>();
        }

        public void CreatePlayer(string playerId, string playerPassword)
        {
            Player newPlayer = new Player(playerId, playerPassword);
            Players.Add(newPlayer);
        }

        public void UpdatePlayerPassword(Player player, string newPassword)
        {
            player.UpdatePassword(newPassword);
        }

        public override void UpdatePassword(string newPassword)
        {
            UserPassword = newPassword;
        }
    }

    public class Player : User
    {
        public Player(string userId, string password) : base(userId, password)
        {
        }

        public override void UpdatePassword(string newPassword)
        {
            UserPassword = newPassword;
        }
    }
}
