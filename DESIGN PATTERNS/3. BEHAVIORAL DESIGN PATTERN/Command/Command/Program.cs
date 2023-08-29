using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    internal class Program
    {
        public interface ICommand
        {
            void Execute();
            void Undo();
        }

        public class InsertTextCommand : ICommand
        {
            private TextEditor _editor;
            private string _text;

            public InsertTextCommand(TextEditor editor, string text)
            {
                _editor = editor;
                _text = text;
            }

            public void Execute()
            {
                _editor.InsertText(_text);
            }

            public void Undo()
            {
                _editor.RemoveText(_text);
            }
        }

        public class DeleteTextCommand : ICommand
        {
            private TextEditor _editor;
            private string _text;

            public DeleteTextCommand(TextEditor editor, string text)
            {
                _editor = editor;
                _text = text;
            }

            public void Execute()
            {
                _editor.RemoveText(_text);
            }

            public void Undo()
            {
                _editor.InsertText(_text);
            }
        }

        public class TextEditor
        {
            private StringBuilder _text = new StringBuilder();

            public void InsertText(string text)
            {
                _text.Append(text);
            }

            public void RemoveText(string text)
            {
                int index = _text.ToString().LastIndexOf(text);
                if (index != -1)
                {
                    _text.Remove(index, text.Length);
                }
            }

            public string GetText()
            {
                return _text.ToString();
            }
        }

        public class CommandHistory
        {
            private Stack<ICommand> _commands = new Stack<ICommand>();

            public void ExecuteCommand(ICommand command)
            {
                command.Execute();
                _commands.Push(command);
            }

            public void Undo()
            {
                if (_commands.Count > 0)
                {
                    ICommand command = _commands.Pop();
                    command.Undo();
                }
            }
        }

        static void Main(string[] args)
        {
            TextEditor editor = new TextEditor();
            CommandHistory history = new CommandHistory();

            ICommand insertCommand = new InsertTextCommand(editor, "Hello, ");
            ICommand deleteCommand = new DeleteTextCommand(editor, "Hello, ");

            history.ExecuteCommand(insertCommand);
            Console.WriteLine("Text after insert: " + editor.GetText());

            history.ExecuteCommand(deleteCommand);
            Console.WriteLine("Text after delete: " + editor.GetText());

            history.Undo();
            Console.WriteLine("Text after undo: " + editor.GetText());
        }
    }


}

