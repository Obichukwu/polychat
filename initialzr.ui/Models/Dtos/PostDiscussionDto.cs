using System;

namespace initialzr.ui.Models.Dtos {

    public class PostDiscussionDto {

        public int PostDiscussionId { get; set; }

        public string Note { get; set; }

        public DateTime Date { get; set; }

        public int PostId { get; set; }

        public PostDiscussionDto() {
        }

        public PostDiscussionDto(PostDiscussion entity) {
            this.PostDiscussionId = entity.Id;
            this.Note = entity.Note;
            this.Date = entity.Date;
            this.PostId = entity.PostId;
        }
    }
}