using System;
using System.Collections.Generic;

namespace initialzr.ui.Models.Dtos {

    public class MessageDto {

        public int MessageId { get; set; }

        public DateTime LastMessageDate { get; set; }

        public virtual ICollection<string> Participants { get; set; }

        public MessageDto() {
        }

        public MessageDto(Message entity) {
            this.MessageId = entity.Id;
            this.LastMessageDate = entity.LastMessageDate;
            this.Participants = new List<string>();

            foreach (var item in entity.Participants) {
                this.Participants.Add(item.LastName + " " + item.FirstName);
            }
        }
    }
}