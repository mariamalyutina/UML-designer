using System;
using System.Collections.Generic;
using System.Text;

namespace UMLDisigner
{
    abstract class AbstractArrowFactory : AbstractFactory
    {
        protected AbstractLine _lineType;
        protected AbstractCap _firstCap;
        protected AbstractCap _endCap;

        public AbstractArrowFactory(bool curved)
        {
            if (curved)
            {
                _lineType = new CurvedLine();
            }
            else
            {
                _lineType = new StraightLine();
            }
        }
        
    
    }
}
