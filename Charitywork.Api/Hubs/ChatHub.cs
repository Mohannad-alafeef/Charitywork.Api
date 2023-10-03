using CharityWork.Core.Models;
using Microsoft.AspNetCore.SignalR;

namespace CharityWork.Api.Hubs {
	public sealed class ChatHub : Hub {
		private readonly static Dictionary<string, User> _users = new Dictionary<string, User>();
		private readonly static Dictionary<string, List<Message>> _chats = new Dictionary<string, List<Message>>();
		public override async Task OnConnectedAsync() {
			await Clients.All.SendAsync("ReceiveMessage", Context.ConnectionId);

		}

		public override async Task OnDisconnectedAsync(Exception? exception) {
			await Clients.All.SendAsync("ReceiveMessage", Context.ConnectionId);
		}
		public async Task StartChat(User user) {
			await Groups.AddToGroupAsync(Context.ConnectionId, Context.ConnectionId);
			_users[Context.ConnectionId] = user;
		}
		public Dictionary<string, User> GetGroups() {

			return _users;
		}
		public async Task JoinGroup(string group) {
			await Groups.AddToGroupAsync(Context.ConnectionId, group);

		}
		public async Task SendMessageToGroup(string group,string userName ,string message,int id) {
			if(!_chats.ContainsKey(group)) {
				_chats[group] = new List<Message>();
			}		
			var m = new Message();
			m.content = message;
			m.Id = id;
			m.Name = userName;
			_chats[group].Add(m);
			await Clients.Group(group).SendAsync("ReceiveGroupMessage", group);
		}
		public List<Message> GetGroupMessage(string group) {
			if(! _chats.ContainsKey(group)) {
				return new List<Message>();
			}
			return _chats[group];
		}
	}
}
