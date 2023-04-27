namespace CopperStudios.Tools
{
    public struct Vector3Int
    {
        // Per Instance
        public int x;
        public int y;
        public int z;

        public int X { get => x; set => x = value;}
        public int Y { get => y; set => y = value;}
        public int Z { get => z; set => z = value; }

        public Vector3Int(int X, int Y, int Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        public Vector3Int(int value)
        {
            x = value;
            y = value;
            z = value;
        }

        // Template Values

        public static Vector3Int One() 
        { 
            return new Vector3Int(1, 1, 1); 
        }
        public static Vector3Int Zero() 
        { 
            return new Vector3Int(0, 0, 0); 
        }
        
        // Math
        public static Vector3Int Add(Vector3Int left, Vector3Int right)
        {
            return new Vector3Int(left.x + right.x, left.y + right.y, left.Z + right.Z); 
        }

        public static Vector3Int Subtract(Vector3Int left, Vector3Int right)
        {
            return new Vector3Int(left.x - right.x, left.y - right.y, left.Z - right.Z); 
        }

        public static Vector3Int Multiply(Vector3Int left, Vector3Int right)
        {
            return new Vector3Int(left.x * right.x, left.y * right.y, left.Z * right.Z); 
        }

        public static Vector3Int Divide(Vector3Int left, Vector3Int right)
        {
            return new Vector3Int(left.x / right.x, left.y / right.y, left.Z / right.Z); 
        }


        public static Vector3Int Multiply(Vector3Int value, int amount)
        {
            return new Vector3Int(value.X * amount, value.Y * amount, value.z * amount); 
        }

        public static Vector3Int Divide(Vector3Int value, int amount)
        {
            return new Vector3Int(value.X / amount, value.Y / amount, value.Z / amount); 
        }
    }
}