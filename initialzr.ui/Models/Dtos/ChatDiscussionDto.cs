using System;

namespace initialzr.ui.Models.Dtos {

    public class ChatDiscussionDto {

        public int ChatDiscussionId { get; set; }

        public string Note { get; set; }

        public DateTime Date { get; set; }

        public int DepartmentId { get; set; }
        public int ProfileId { get; set; }

        public ChatDiscussionDto() {
        }

        public ChatDiscussionDto(ChatDiscussion entity) {
            this.ChatDiscussionId = entity.Id;
            this.Note = entity.Note;
            this.Date = entity.Date;
            this.DepartmentId = entity.DepartmentId;
            this.ProfileId = entity.ProfileId;
        }
    }
}