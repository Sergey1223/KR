using System;
using System.Collections.Generic;

namespace ClassLibrarySCTT
{
    [Serializable]
    public enum Type { Standart, StandartM, Comparison, Sequence }

    [Serializable]
    public class Question
    {
#region Поля
        private int _Number;
        private string _Text;
        public List<List<string>> Choices;
        public List<int> ExtendChoices;
        private Type _Type;
        #endregion

#region Свойства
        /// <summary>
        /// Возвращает или задает номер вопроса.
        /// </summary>
        public int Number
        {
            set { _Number = value; }
            get { return _Number; }
        }
        /// <summary>
        /// Возвращает или задает текст вопроса.
        /// </summary>
        public string Text
        {
            set { _Text = value; }
            get { return _Text; }
        }
#endregion

        /// <summary>
        /// Возвращает или задает тип вопроса.
        /// </summary>
        public Type Type
        {
            set { _Type = value; }
            get { return _Type; }
        }

        /// <summary>
        /// Инициализирует новый эеземпляр класса ClassLibrarySCTT.Question.
        /// </summary>
        /// <param name="Number"> Номер вопроса </param>
        public Question(int Number)
        {
            this.Number = Number;
            _Text = "";
            Choices = new List<List<string>>();
            Type = Type.Standart;
        }
    }
}
