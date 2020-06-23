public class Solution {
    public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4) {
        
        // Validation checks:
        // 1: Ensure that the 4 points are different
        // 2: All sides are of equal length
        // 3: All four corners are 90deg in angle
        //      - It can be the case that the square is angled.
        //      - Slope is unreliable since it can be that the square has infinite slope
        // 
        
        // First, wrap them in implicit objects (tuples)
        var a = (p1[0], p1[1]);
        var b = (p2[0], p2[1]);
        var c = (p3[0], p3[1]);
        var d = (p4[0], p4[1]);
        
        // Check each possible angle. Each call causes an evaluation of 3 times. For a total of 12 evals.
        // But this is because it covers all possible combinations of common points and angles.
        return IsSquare(a, b, c, d) + IsSquare(b, a, c, d) + IsSquare(c, a, b, d) + IsSquare(d, a, b, c) == 4;   
    }
    
    // Note that we need to do this 6 times, since its all permutations of a square
    // If the opposite common points form 2 right angles, they likely form a square or rectangle
    // Moreover, those right angles must also be of the same length with their vectors.
    private int IsSquare((int x, int y) a, 
                                       (int x, int y) b, 
                                       (int x, int y) c,
                                       (int x, int y) d) {
        var count = 0;
        
        // Angle 1: a->c, a->d
        if (IsRightAngleAndSameDist(a, c, d)) {            
            count++;
        }
        
        // Angle 2: a->b, a->d
        if (IsRightAngleAndSameDist(a, b, d)) {        
            count++;
        }
        
        // Angle 3: a->b, a->c
        if (IsRightAngleAndSameDist(a, b, c)) {           
            count++;
        }
        
        return count;
    }
    
    // Finds the angle between two vectors that share a common point
    // This also compares their distance
    private bool IsRightAngleAndSameDist((int x, int y) common, (int x, int y) vector1, (int x, int y) vector2) {
        var vectorDotProduct = ((vector1.x-common.x) *(vector2.x-common.x)) 
            + ((vector1.y-common.y) * (vector2.y-common.y));
        var distV1 = FindDistance(common, vector1);
        var distV2 = FindDistance(common, vector2);

        return Math.Acos(vectorDotProduct/(distV1*distV2)) == Math.Acos(0) && distV1 == distV2;
    }
    
    // Helper function to find the distance between two points.
    private double FindDistance((int x, int y) c1, (int x, int y) c2) {     
        return Math.Sqrt(Math.Pow((double)c2.x - c1.x, 2) + Math.Pow((double)c2.y - c1.y, 2));
    }    
}