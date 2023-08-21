using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    public class WeaponSprite : WeaponComponent<WeaponSpriteData, AttackSprites>
    {
        private SpriteRenderer baseSpriteRenderer;
        private SpriteRenderer weaponSpriteRenderer;

        private int currentWeaponSpriteIndex;

        private Sprite[] currentPhaseSprites;

        protected override void HandleEnter()
        {
            base.HandleEnter();
            
            currentWeaponSpriteIndex = 0;
        }

        private void HandleEnterAttackPhase(AttackPhases phase)
        {
            currentWeaponSpriteIndex = 0;
            currentPhaseSprites = currentAttackData.PhaseSprites.FirstOrDefault(data => data.Phase == phase).Sprites;
        }

        private void HandleBaseSpriteChange(SpriteRenderer sr)
        {
            if(!isAttackActive)
            {
                weaponSpriteRenderer.sprite = null;
                return;
            }

            if(currentWeaponSpriteIndex >= currentPhaseSprites.Length)
            {
                Debug.LogWarning($"{weapon.name} weapon sprite length mismatch");
                return;
            }

            weaponSpriteRenderer.sprite = currentPhaseSprites[currentWeaponSpriteIndex];

            currentWeaponSpriteIndex++;
        }

        protected override void Start()
        {
            base.Start();

            baseSpriteRenderer = weapon.BaseGameObject.GetComponent<SpriteRenderer>();
            weaponSpriteRenderer = weapon.WeaponSpriteGameObject.GetComponent<SpriteRenderer>();

            data = weapon.Data.GetData<WeaponSpriteData>();
            
            baseSpriteRenderer.RegisterSpriteChangeCallback(HandleBaseSpriteChange);

            eventHandler.OnEnterAttackPhase += HandleEnterAttackPhase;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            baseSpriteRenderer.UnregisterSpriteChangeCallback(HandleBaseSpriteChange);

            eventHandler.OnEnterAttackPhase -= HandleEnterAttackPhase;
        }
    }
}