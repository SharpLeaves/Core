using UnityEngine;

namespace Core{
    public abstract class Creature : Entity{
        public PhysicsController physicsController;
        public GroundedTester groundedTester;
    }
}