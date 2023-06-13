using System;

namespace Interface
{
   public interface IHittable
   {
      public event Action<int> OnDamageTaken; // Event triggered when damage is taken
      public event Action<int> OnHealthTaken; // Event triggered when health is restored
      public void OnDamageReceived(int amount); // Method called when damage is received
      public void OnHealthReceived(int amount); // Method called when health is received
   }
}

