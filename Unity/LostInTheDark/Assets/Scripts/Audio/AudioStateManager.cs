using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStateManager : MonoBehaviour
{
    [SerializeField]
    private AudioManager audioManager;


    private enum Slot
    {
        None,
        Spawn,
        BleedingSwamps,
        SerpentVigne,
        Maldirach,
        Carniviste,
        MoonShadowClearing,
        ReineGrouillante,
        OceanPurrulant,
        Ossequine,
        HowlingSwamps,
        Gate,
        End,
        SeventhStar,
    }


    private bool hasReachedSnake = false;
    private bool hasReachedEnd = false;
    private bool isDead = false;

    public void UpdateSlotIndex(int slotindex)
    {
        switch ((Slot)slotindex)
        {
            case Slot.None:
                {
                    // Add Wiise calls
                }
                break;
            case Slot.Spawn:
                if (hasReachedEnd || isDead)
                    ResetGame();
                {
                    // Add Wiise calls
                }
                break;
            case Slot.BleedingSwamps:
                {
                    // Add Wiise calls
                }
                break;
            case Slot.SerpentVigne:
                hasReachedSnake = true;
                {
                    // Add Wiise calls
                }
                break;
            case Slot.Maldirach:
                {
                    // Add Wiise calls
                }
                break;
            case Slot.Carniviste:
                {
                    isDead = true;
                    // Add Wiise calls
                }
                break;
            case Slot.MoonShadowClearing:
                {
                    // Add Wiise calls
                }
                break;
            case Slot.ReineGrouillante:
                {
                    isDead = true;
                    // Add Wiise calls
                }
                break;
            case Slot.OceanPurrulant:
                {
                    isDead = true;
                    // Add Wiise calls
                }
                break;
            case Slot.Ossequine:
                {
                    isDead = true;
                    // Add Wiise calls
                }
                break;
            case Slot.HowlingSwamps:
                if (hasReachedSnake)
                {
                    // Add Wiise calls (not dead)
                }
                else
                {
                    // Add Wiise calls (dead)
                }
                break;
            case Slot.Gate:
                {
                    // Add Wiise calls
                }
                break;
            case Slot.End:
                hasReachedEnd = true;
                {
                    // Add Wiise calls
                }
                break;
            case Slot.SeventhStar:
                {
                    isDead = true;
                    // Add Wiise calls
                }
                break;
        }
    }

    void ResetGame()
    {
        hasReachedSnake = false;
        hasReachedEnd = false;
        isDead = false;

        // Add Wiise calls

        audioManager.StopAll();
    }
}
