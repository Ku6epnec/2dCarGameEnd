using UnityEngine;


namespace Company.Project.Content
{
    [CreateAssetMenu(fileName = "Ability item", menuName = "Ability item", order = 0)]
    public class AbilityItemConfig : ScriptableObject
    {
        #region Fields

        public ItemConfig itemConfig;
        public GameObject view;
        public AbilityType type;
        public float value;

        public int Id => itemConfig.id;

        #endregion
    }

    public enum AbilityType
    {
        None,
        Gun,
    }
}