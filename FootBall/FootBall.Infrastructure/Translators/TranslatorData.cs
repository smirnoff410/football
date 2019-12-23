using System;

namespace FootBall.Infrastructure.Translators
{
    public class TranslatorData
    {
        public Type Source { get; set; }
        public Type Destination { get; set; }
        public ITranslator Translator { get; set; }
    }
}