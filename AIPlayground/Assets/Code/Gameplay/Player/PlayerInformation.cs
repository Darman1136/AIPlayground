using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation {
    private bool firing = false;
    public bool Firing {
        get {
            return firing;
        }
        set {
            firing = value;
        }
    }

    private bool reloading = false;
    public bool Reloading {
        get {
            return reloading;
        }
        set {
            reloading = value;
        }
    }

    private int clipSize = 30;
    public int ClipSize {
        get {
            return clipSize;
        }
    }

    private int bulletsRemaining = 30;
    public int BulletsRemaining {
        get {
            return bulletsRemaining;
        }
        set {
            bulletsRemaining = value;
            if(bulletsRemaining < 0) {
                bulletsRemaining = 0;
            }
        }
    }

    public bool NeedsReload() {
        return bulletsRemaining == 0;
    }

    public void Reload() {
        BulletsRemaining = ClipSize;
    }

    public void ShotFired() {
        BulletsRemaining--;
    }
}
