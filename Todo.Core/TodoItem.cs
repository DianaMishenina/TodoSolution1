using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Todo.Core
{
    public class TodoItem
    {
        [JsonInclude]
        public Guid Id { get; private set; }
        [JsonInclude]
        public string Title { get; private set; };
        [JsonInclude]
        public bool IsDone { get; private set; }

        public TodoItem(string title)
        {
            Id = Guid.NewGuid();
            Title = title?.Trim() ?? throw new ArgumentNullException(nameof(title));
        }

        //[JsonConstructor]
        public TodoItem(Guid id, string title, bool isDone)
        {
            Id = id;
            Title = title;
            IsDone = isDone;
        }

        public void MarkDone() => IsDone = true;
        public void MarkUndone() => IsDone = false;
        public void Rename(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle)) 
                throw new ArgumentException("Title required", nameof(newTitle)); 
            Title = newTitle.Trim();
        }
    }
}

