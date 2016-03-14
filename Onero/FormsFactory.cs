using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Onero.Dialogs;
using Onero.Loader;

namespace Onero
{
    public interface IEditorForm
    {
        Rule Entity { get; set; }
        string Title { get; set; }
        DialogResult ShowDialog();
        void Dispose();
    }

    public class FormsFactory
    {
        static readonly Dictionary<Type, Func<IEditorForm>> forms = 
            new Dictionary<Type, Func<IEditorForm>> {
                                            { typeof(Rule), () => new RulesEditor
                                                {
                                                    StartPosition = FormStartPosition.CenterParent,
                                                    Title = "Please enter a new data extract:",
                                                    Entity = new Rule(string.Empty, string.Empty)
                                                }
                                            },
                                           { typeof(DataExtractItem), () => new ExtractorEditor
                                                {
                                                    StartPosition = FormStartPosition.CenterParent,
                                                    Title = "Please enter a new data extract:",
                                                    Entity = new DataExtractItem(string.Empty, string.Empty)
                                                }
                                            }
                                        };

        public static IEditorForm GetChildForm<T>() where T : Rule
        {
            return forms[typeof(T)]();
        }
    }
}
