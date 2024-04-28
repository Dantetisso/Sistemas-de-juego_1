using System.Collections;
using System.Collections.Generic;

public interface IDamageable 
{
    void UpdateHealth();

    void GetDamage(int damage);

    void Heal(int heal);
       
    void Death();

    bool IsAlive();

}
