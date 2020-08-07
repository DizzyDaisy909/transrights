using System.Collections.Generic;

namespace rjiendaujughyi.AST
{
    public interface IAcui { }
    public interface IAcuiTopLevel : IAcui {}
    public interface IAcuiStatement : IAcui {}
    public interface IAcuiExpr : IAcuiStatement { }
    public interface IAcuiLiteral : IAcuiExpr { }
    public class AcuiFunction : IAcuiTopLevel
    {
        public AcuiIdentifierLiteral name { get; set; }
        public List<IAcuiStatement> statements { get; set; }
        public override string ToString() {
            return $"func {name.reference} {'{'}\n{statements.ConvertAll(s => '\n'+s.ToString())}\n{'}'}";
        }
    }
    public class AcuiIdentifierLiteral : IAcuiLiteral
    {
        public string reference { get; set; }
        public override string ToString() => reference;
    }
    public class AcuiStringLiteral : IAcuiLiteral
    {
        public string value { get; set; }
        public override string ToString() => '`' + value + '`';
    }
    public class AcuiMessage : IAcuiExpr
    {
        public AcuiIdentifierLiteral target { get; set; }
        public List<(string, IAcuiExpr)> selectors { get; set; }
        public override string ToString()
        {
            return $"({target} {string.Join(" ", selectors.ConvertAll(item => $"{item.Item1}:{item.Item2}"))})";
        }
    }
}