using System;

namespace initialzr.ui.Models.Dtos {

    public class MessageDiscussionDto {

        public int MessageDiscussionId { get; set; }

        public string Note { get; set; }

        public DateTime Date { get; set; }

        public int MessageId { get; set; }

        public int PosterId { get; set; }

        public MessageDiscussionDto() {
        }

        public MessageDiscussionDto(MessageDiscussion entity) {
            this.MessageDiscussionId = entity.Id;
            this.Note = entity.Note;
            this.Date = entity.Date;

            this.MessageId = entity.MessageId;
            this.PosterId = entity.ProfileId;
        }
    }
}