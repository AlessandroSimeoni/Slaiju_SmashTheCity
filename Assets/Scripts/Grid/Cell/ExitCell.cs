using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Grid.Cell
{
    public class ExitCell : BaseCell
    {
        [SerializeField] private ExitCellView view = null;


#if UNITY_EDITOR
        private void OnValidate() 
        {
            ID = CellID.Exit;
            safeSide.Clear();
        }
#endif

        public async UniTask ActivateExit()
        {
            EnableAllSafeSides();
            await view.ChangeView();
        }
    }
}
