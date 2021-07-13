using UnityEngine;

namespace Company.Project.Content
{
    [CreateAssetMenu(fileName = "Upgrade item", menuName = "Upgrade item", order = 0)]
    public class UpgradeItemConfig : ScriptableObject
    {
        #region Fields

        public ItemConfig itemConfig;
        public UpgradeType type;
        public float value;

        public int Id => itemConfig.id;

        #endregion
    }

    public enum UpgradeType
    {
        None,
        Speed,
    }
}