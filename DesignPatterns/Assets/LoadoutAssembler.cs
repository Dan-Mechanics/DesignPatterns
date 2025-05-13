using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class LoadoutAssembler : MonoBehaviour
    {
        [Header("Weapon")]
        [SerializeField] private BaseWeapon baseWeapon = default;
        [SerializeField] private WeaponDecorator removableDecorator;

        /// <summary>
        /// You could send this somewhere elsel ike loadoutassembler or something.
        /// </summary>
        [Tooltip("The player assembles this before the game starts.")]
        [SerializeField] private List<WeaponDecorator> weaponDecorators = default;

        public IWeapon AssembleWeapon()
        {
            IWeapon weapon = baseWeapon;

            for (int i = 0; i < weaponDecorators.Count; i++)
            {
                weapon = weaponDecorators[i].Decorate(weapon);
            }

            return weapon;
        }

        public WeaponDecorator GetRemovableDecorator() => removableDecorator;
    }
}