using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Physics;

namespace Core{
    public abstract class Creature : Entity{
        public PhysicsController physicsController;
        public GroundedTester groundedTester;
    }
}