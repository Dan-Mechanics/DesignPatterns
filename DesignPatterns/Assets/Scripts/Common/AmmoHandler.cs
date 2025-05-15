using System;

namespace DesignPatterns
{
    public class AmmoHandler
    {
        public event Action<int, int> OnNewAmmo;
        
        private int bullets;
        private readonly int maxBullets;

        public AmmoHandler(int bullets, int maxBullets)
        {
            this.bullets = bullets;
            this.maxBullets = maxBullets;

            OnNewAmmo?.Invoke(bullets, maxBullets);
        }

        public bool GetReloadable() 
        {
            return bullets < maxBullets;
        }

        public bool CanShoot() 
        {
            return bullets > 0;
        }

        public void Shoot() 
        {
            bullets--;
            OnNewAmmo?.Invoke(bullets, maxBullets);
        }
    }
}