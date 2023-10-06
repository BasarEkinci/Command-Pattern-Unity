using UnityEngine;

namespace Commands
{
    public class CaptureCommand : CommandManager.ICommand
    {
        private Vector3Int m_Start;
        private Vector3Int m_End;

        private Unit m_Captured;
        private Unit m_Capturing;
        
        public CaptureCommand(Vector3Int start, Vector3Int end)
        {
            m_Start = start;
            m_End = end;
        }
        
        public void Execute()
        {
            m_Captured = Gameboard.Instance.GetUnit(m_End);
            m_Capturing = Gameboard.Instance.GetUnit(m_Start);
            
            Gameboard.Instance.MoveUnit(m_Capturing,m_End);
            Gameboard.Instance.TakeOutUnit(m_Captured);
            Gameboard.Instance.SwitchTeam();
        }

        public void Undo()
        {
            Gameboard.Instance.MoveUnit(m_Capturing,m_Start);
            Gameboard.Instance.MoveUnit(m_Captured,m_End);
            Gameboard.Instance.SwitchTeam();
        }
    }
}