using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Core.Tests
{
    public class TodoListTests
    {
        private readonly string _filePath = Path.GetTempFileName();

        [Fact]
        public void Add_IncreasesCount()
        {
            var list = new TodoList();
            list.Add("  task  ");
            Assert.Equal(1, list.Count);
            Assert.Equal("task", list.Items.First().Title);
        }

        [Fact]
        public void Remove_ById_Works()
        {
            var list = new TodoList();
            var item = list.Add("a");
            Assert.True(list.Remove(item.Id));
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Find_ReturnsMatches()
        {
            var list = new TodoList();
            list.Add("Buy milk");
            list.Add("Read book");
            var found = list.Find("buy").ToList();
            Assert.Single(found);
            Assert.Equal("Buy milk", found[0].Title);
        }

        [Fact]
        public void SaveAndLoad_Works()
        {
            var list = new TodoList();
            list.Add("Task 1");
            list.Add("Task 2");

            var path = "tasks.json";
            list.Save(path);

            var newList = new TodoList();
            newList.Load(path);

            Assert.Equal(2, newList.Count);
            Assert.Equal("Task 1", newList.Items[0].Title);
            Assert.Equal("Task 2", newList.Items[1].Title);

            if (File.Exists(path)) 
                File.Delete(path);
        }
    }
}
