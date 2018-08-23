using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{

    [CreateAssetMenu(menuName = "AI/Brain")]
    public class AIBrain : ScriptableObject
    {

        // This works - but is a busted fuckin mess and needs to be refactored into less copy paste



        public struct StateControllerContainer
        {
            public Vector3 _location;
            public AIStateController _stateController;

            public void New(AIStateController stateController)
            {
                _location = stateController.gameObject.transform.position;
                _stateController = stateController;
            }
        }

        public struct FarmContainer
        {
            public Vector3 _location;
            public Farm _farm;

            public void New(Farm stateController)
            {
                _location = stateController.gameObject.transform.position;
                _farm = stateController;
            }
        }

        public List<StateControllerContainer> listOfAis;
        public List<AIStateController> ListOfNewAgents;
        public List<FarmContainer> listOfFarms;
        public List<Farm> ListOfNewFarms;


        //public List<int> myintes;



        public void AddAgent(AIStateController stateController)
        {
            StateControllerContainer container = new StateControllerContainer();
            container.New(stateController);
            listOfAis.Add(container);
        }

        public void RemoveAgent(AIStateController stateController)
        {
            for (int i = 0; i < listOfAis.Count; i++)
            {
                if (listOfAis[i]._stateController == stateController)
                {
                    listOfAis.RemoveAt(i);
                }
            }
        }
        public void RemoveFarm(Farm farm)
        {
            for (int i = 0; i < listOfFarms.Count; i++)
            {
                if (listOfFarms[i]._farm == farm)
                {
                    listOfFarms.RemoveAt(i);
                }
            }
        }

        public void AddFarm(Farm farm)
        {
            FarmContainer container = new FarmContainer();
            container._farm = farm;
            container._location = farm.transform.position;
            listOfFarms.Add(container);
        }

        public void AddNewAgent(AIStateController stateController)
        {
            ListOfNewAgents.Add(stateController);
        }

        public void RemoveNewAgent(AIStateController stateController)
        {
            for (int i = 0; i < ListOfNewAgents.Count; i++)
            {
                if (ListOfNewAgents[i] == stateController)
                {
                    ListOfNewAgents.RemoveAt(i);
                }
            }
        }

        public void AddNewFarm(Farm farm)
        {
            ListOfNewFarms.Add(farm);
        }

        public void RemoveNewFarm(Farm farm)
        {
            for (int i = 0; i < ListOfNewFarms.Count; i++)
            {
                if (ListOfNewFarms[i] == farm)
                {
                    ListOfNewFarms.RemoveAt(i);
                }
            }
        }

        public List<int> myListOfItns;

        void CheckListForType()
        {
            myListOfItns.GetType();
        }

        //public List<T> myListOfgeneric;

        


    }
}
