#region License

// Copyright (C) Tomáš Pažourek, 2016
// All rights reserved.
// 
// Distributed under MIT license as a part of project Rationals.
// https://github.com/tompazourek/Rationals

#endregion

using System.Numerics;
using System.Threading.Tasks;

namespace Rationals
{
    public partial struct Rational
    {
        // http://bigintegers.blogspot.de/2013/07/nth-root-power.html
        private static BigInteger BigIntegerRoot(BigInteger number, int root)
        {
            if (root % 2 == 0 && number.Sign < 0)
            {
                number = BigInteger.Negate(number);
            }

            int sr_X = (BigIntegerBitLength(number) - 1) / root * root - root;
            BigInteger R0 = 1;
            int n = 1;

            while (sr_X >= 0)
            {
                R0++;
                R0 = PartialRoot(number >> sr_X, R0, n, root);
                n *= 2;
                sr_X -= n * root;
            }

            sr_X += n * root;

            if (sr_X == 0)
            {
                return R0;
            }

            R0++;
            R0 = PartialRoot(number, R0, sr_X / root, root);
            return R0;
        }

        // http://bigintegers.blogspot.de/2010/11/square-division-power-square-root.html
        private static BigInteger BigIntegerPow(BigInteger number, int exponent)
        {
            if (exponent > 1)
                return ((exponent & 1) == 0) ? BigIntegerSquare(BigIntegerPow(number, exponent / 2)) : BigIntegerFastMultiply(number, BigIntegerSquare(BigIntegerPow(number, exponent / 2)));
            return exponent == 0 ? 1 : number;
        }

        private static BigInteger BigIntegerFastMultiply(BigInteger op1, BigInteger op2)
        {
            int n = BigIntegerBitLength(op1);
            if (n <= 7500)
                return op1 * op2;
            BigInteger Mask = (BigInteger.One << n) - 1;
            BigInteger T = BigIntegerMultiply(op1, op2 & Mask, n);
            op2 >>= n;
            int s = n;
            while (op2 > 0)
            {
                T += BigIntegerMultiply(op1, op2 & Mask, n) << s;
                op2 >>= n;
                s += n;
            }
            return T;
        }

        // http://bigintegers.blogspot.de/2010/11/square-division-power-square-root.html
        private static BigInteger BigIntegerSquare(BigInteger number)
        {
            return Square(number, number.Sign * number.ToByteArray().Length << 3);
        }

        // http://bigintegers.blogspot.de/2010/09/toom-cook-2-random-bigintegers-bit.html
        private static int BigIntegerBitLength(BigInteger number)
        {
            byte[] bytes = (number.Sign * number).ToByteArray();
            int i = bytes.Length - 1;
            return i * 8 | BitLengthMostSignificantByte(bytes[i]);
        }

        private static BigInteger PartialRoot(BigInteger X, BigInteger R0, int n, int y)
        {
            BigInteger S, Z, T;
            S = R0 << n;
            Z = BigIntegerPow(R0, y - 1);
            T = (y - 1) * S + DivideQuotient((X >> (y - 1) * n), Z);
            R0 = T / y;
            do
            {
                S = R0;
                Z = BigIntegerPow(S, y - 1);
                T = (y - 1) * S + DivideQuotient(X, Z);
                R0 = T / y;
            }
            while (R0 < S);
            return S;
        }

        // http://bigintegers.blogspot.de/2010/09/toom-cook-2-random-bigintegers-bit.html
        private static BigInteger BigIntegerMultiply(BigInteger U, BigInteger V, int n)
        {
            if (n <= 3000)
                return U * V;
            if (n <= 6000)
                return ToomCookMultiply2(U, V, n);
            if (n <= 10000)
                return ToomCookMultiply3(U, V, n);
            if (n <= 40000)
                return ToomCookMultiply4(U, V, n);
            return ToomCookMultiply2P(U, V, n);
        }

        private static BigInteger SmallMultiply(BigInteger U, BigInteger V, int n)
        {
            if (n <= 3000)
                return U * V;
            if (n <= 6000)
                return ToomCookMultiply2(U, V, n);
            if (n <= 10000)
                return ToomCookMultiply3(U, V, n);
            return ToomCookMultiply4(U, V, n);
        }

        private static int BitLengthMostSignificantByte(byte b)
        {
            return b < 08 ? b < 02 ? b < 01 ? 0 : 1 :
                                     b < 04 ? 2 : 3 :
                            b < 32 ? b < 16 ? 4 : 5 :
                                     b < 64 ? 6 : 7;
        }

        private static BigInteger Square(BigInteger U, int n)
        {
            if (n <= 700)
                return U * U;
            if (n <= 3000)
                return BigInteger.Pow(U, 2);
            if (n <= 6000)
                return Square2(U, n);
            if (n <= 10000)
                return Square3(U, n);
            if (n <= 40000)
                return Square4(U, n);
            return Square2P(U, n);
        }

        private static BigInteger SmallSquare(BigInteger U, int n)
        {
            if (n <= 3000)
                return BigInteger.Pow(U, 2);
            if (n <= 6000)
                return Square2(U, n);
            if (n <= 10000)
                return Square3(U, n);
            return Square4(U, n);
        }

        private static BigInteger Square2(BigInteger U1, int n)
        {
            n >>= 1;
            BigInteger U0 = U1 & ((BigInteger.One << n) - 1);
            U1 >>= n;
            BigInteger P0 = SmallSquare(U0, n);
            BigInteger P2 = SmallSquare(U1, n);
            return ((P2 << n) + (SmallSquare(U0 + U1, n) - (P0 + P2)) << n) + P0;
        }

        private static BigInteger Square3(BigInteger U2, int n)
        {
            n = (int)((long)(n) * 0x55555556 >> 32);
            BigInteger Mask = (BigInteger.One << n) - 1;
            BigInteger U0 = U2 & Mask;
            U2 >>= n;
            BigInteger U1 = U2 & Mask;
            U2 >>= n;
            BigInteger W0 = SmallSquare(U0, n);
            BigInteger W4 = SmallSquare(U2, n);
            BigInteger P3 = SmallSquare((((U2 << 1) + U1) << 1) + U0, n);
            U2 += U0;
            BigInteger P2 = SmallSquare(U2 - U1, n);
            BigInteger P1 = SmallSquare(U2 + U1, n);
            BigInteger W2 = (P1 + P2 >> 1) - (W0 + W4);
            BigInteger W3 = W0 - P1;
            W3 = ((W3 + P3 - P2 >> 1) + W3) / 3 - (W4 << 1);
            BigInteger W1 = P1 - (W4 + W3 + W2 + W0);
            return ((((W4 << n) + W3 << n) + W2 << n) + W1 << n) + W0;
        }

        private static BigInteger Square4(BigInteger U3, int n)
        {
            n >>= 2;
            BigInteger Mask = (BigInteger.One << n) - 1;
            BigInteger U0 = U3 & Mask;
            U3 >>= n;
            BigInteger U1 = U3 & Mask;
            U3 >>= n;
            BigInteger U2 = U3 & Mask;
            U3 >>= n;
            BigInteger W0 = SmallSquare(U0, n);                                   //  0
            U0 += U2;
            U1 += U3;
            BigInteger P1 = SmallSquare(U0 + U1, n);                              //  1
            BigInteger P2 = SmallSquare(U0 - U1, n);                              // -1
            U0 += 3 * U2;
            U1 += 3 * U3;
            BigInteger P3 = SmallSquare(U0 + (U1 << 1), n);                       //  2
            BigInteger P4 = SmallSquare(U0 - (U1 << 1), n);                       // -2
            BigInteger P5 = SmallSquare(U0 + 12 * U2 + ((U1 + 12 * U3) << 2), n); //  4
            BigInteger W6 = SmallSquare(U3, n);                                   //  inf
            BigInteger W1 = P1 + P2;
            BigInteger W4 = (((((P3 + P4) >> 1) - (W1 << 1)) / 3 + W0) >> 2) - 5 * W6;
            BigInteger W2 = (W1 >> 1) - (W6 + W4 + W0);
            P1 = P1 - P2;
            P4 = P4 - P3;
            BigInteger W5 = ((P1 >> 1) + (5 * P4 + P5 - W0 >> 4) - ((((W6 << 4) + W4) << 4) + W2)) / 45;
            W1 = ((P4 >> 2) + (P1 << 1)) / 3 + (W5 << 2);
            BigInteger W3 = (P1 >> 1) - (W1 + W5);
            return ((((((W6 << n) + W5 << n) + W4 << n) + W3 << n) + W2 << n) + W1 << n) + W0;
        }

        private static BigInteger Square2P(BigInteger A, int n)
        {
            n >>= 1;
            BigInteger[] U = new BigInteger[3];
            U[0] = A & ((BigInteger.One << n) - 1);
            A >>= n;
            U[2] = A;
            U[1] = U[0] + A;
            BigInteger[] P = new BigInteger[3];
            Parallel.For(0, 3, (int i) => P[i] = SmallSquare(U[i], n));
            return ((P[2] << n) + P[1] - (P[0] + P[2]) << n) + P[0];
        }

        private static BigInteger ToomCookMultiply2(BigInteger U1, BigInteger V1, int n)
        {
            n >>= 1;
            BigInteger Mask = (BigInteger.One << n) - 1;
            BigInteger U0 = U1 & Mask;
            U1 >>= n;
            BigInteger V0 = V1 & Mask;
            V1 >>= n;
            BigInteger P0 = SmallMultiply(U0, V0, n);
            BigInteger P2 = SmallMultiply(U1, V1, n);
            return ((P2 << n) + (SmallMultiply(U0 + U1, V0 + V1, n) - (P0 + P2)) << n) + P0;
        }

        private static BigInteger ToomCookMultiply3(BigInteger U2, BigInteger V2, int n)
        {
            n = (int)((long)(n) * 0x55555556 >> 32); // n /= 3;
            BigInteger Mask = (BigInteger.One << n) - 1;
            BigInteger U0 = U2 & Mask;
            U2 >>= n;
            BigInteger U1 = U2 & Mask;
            U2 >>= n;
            BigInteger V0 = V2 & Mask;
            V2 >>= n;
            BigInteger V1 = V2 & Mask;
            V2 >>= n;
            BigInteger W0 = SmallMultiply(U0, V0, n);
            BigInteger W4 = SmallMultiply(U2, V2, n);
            BigInteger P3 = SmallMultiply((((U2 << 1) + U1) << 1) + U0, (((V2 << 1) + V1 << 1)) + V0, n);
            U2 += U0;
            V2 += V0;
            BigInteger P2 = SmallMultiply(U2 - U1, V2 - V1, n);
            BigInteger P1 = SmallMultiply(U2 + U1, V2 + V1, n);
            BigInteger W2 = (P1 + P2 >> 1) - (W0 + W4);
            BigInteger W3 = W0 - P1;
            W3 = ((W3 + P3 - P2 >> 1) + W3) / 3 - (W4 << 1);
            BigInteger W1 = P1 - (W4 + W3 + W2 + W0);
            return ((((W4 << n) + W3 << n) + W2 << n) + W1 << n) + W0;
        }

        private static BigInteger ToomCookMultiply4(BigInteger U3, BigInteger V3, int n)
        {
            n >>= 2;
            BigInteger Mask = (BigInteger.One << n) - 1;
            BigInteger U0 = U3 & Mask;
            U3 >>= n;
            BigInteger U1 = U3 & Mask;
            U3 >>= n;
            BigInteger U2 = U3 & Mask;
            U3 >>= n;
            BigInteger V0 = V3 & Mask;
            V3 >>= n;
            BigInteger V1 = V3 & Mask;
            V3 >>= n;
            BigInteger V2 = V3 & Mask;
            V3 >>= n;

            BigInteger W0 = SmallMultiply(U0, V0, n);                               //  0
            U0 += U2;
            U1 += U3;
            V0 += V2;
            V1 += V3;
            BigInteger P1 = SmallMultiply(U0 + U1, V0 + V1, n);                     //  1
            BigInteger P2 = SmallMultiply(U0 - U1, V0 - V1, n);                     // -1
            U0 += 3 * U2;
            U1 += 3 * U3;
            V0 += 3 * V2;
            V1 += 3 * V3;
            BigInteger P3 = SmallMultiply(U0 + (U1 << 1), V0 + (V1 << 1), n);       //  2
            BigInteger P4 = SmallMultiply(U0 - (U1 << 1), V0 - (V1 << 1), n);       // -2
            BigInteger P5 = SmallMultiply(U0 + 12 * U2 + ((U1 + 12 * U3) << 2),
                           V0 + 12 * V2 + ((V1 + 12 * V3) << 2), n); //  4
            BigInteger W6 = SmallMultiply(U3, V3, n);                               //  inf

            BigInteger W1 = P1 + P2;
            BigInteger W4 = (((((P3 + P4) >> 1) - (W1 << 1)) / 3 + W0) >> 2) - 5 * W6;
            BigInteger W2 = (W1 >> 1) - (W6 + W4 + W0);
            P1 = P1 - P2;
            P4 = P4 - P3;
            BigInteger W5 = ((P1 >> 1) + (5 * P4 + P5 - W0 >> 4) - ((((W6 << 4) + W4) << 4) + W2)) / 45;
            W1 = ((P4 >> 2) + (P1 << 1)) / 3 + (W5 << 2);
            BigInteger W3 = (P1 >> 1) - (W1 + W5);
            return ((((((W6 << n) + W5 << n) + W4 << n) + W3 << n) + W2 << n) + W1 << n) + W0;
        }

        private static BigInteger ToomCookMultiply2P(BigInteger A, BigInteger B, int n)
        {
            n >>= 1;
            BigInteger Mask = (BigInteger.One << n) - 1;
            BigInteger[] U = new BigInteger[3];
            U[0] = A & Mask;
            A >>= n;
            U[2] = A;
            U[1] = U[0] + A;
            BigInteger[] V = new BigInteger[3];
            V[0] = B & Mask;
            B >>= n;
            V[2] = B;
            V[1] = V[0] + B;
            BigInteger[] P = new BigInteger[3];
            Parallel.For(0, 3, (int i) => P[i] = SmallMultiply(U[i], V[i], n));
            return ((P[2] << n) + P[1] - (P[0] + P[2]) << n) + P[0];
        }

        private static BigInteger DivideQuotient(BigInteger A, BigInteger B)
        {
            BigInteger[] QR = DivideQuotientAndRemainder(A, B);
            return QR[0];
        }

        private static BigInteger[] DivideQuotientAndRemainder(BigInteger A, BigInteger B)
        {
            int n = BigIntegerBitLength(B);
            int m = BigIntegerBitLength(A) - n;
            if (m <= 6000)
                return SmallDivRem(A, B);
            int signA = A.Sign;
            A *= signA;
            int signB = B.Sign;
            B *= signB;
            BigInteger[] QR = new BigInteger[2];
            if (m <= n)
                QR = Divide21(A, B, n);
            else
            {
                BigInteger Mask = (BigInteger.One << n) - 1;
                m /= n;
                BigInteger[] U = new BigInteger[m];
                int i = 0;
                for (; i < m; i++)
                {
                    U[i] = A & Mask;
                    A >>= n;
                }
                QR = Divide21(A, B, n);
                A = QR[0];
                for (i--; i >= 0; i--)
                {
                    QR = Divide21(QR[1] << n | U[i], B, n);
                    A = A << n | QR[0];
                }
                QR[0] = A;
            }
            QR[0] *= signA * signB;
            QR[1] *= signA;
            return QR;
        }

        private static BigInteger[] SmallDivRem(BigInteger A, BigInteger B)
        {
            BigInteger[] QR = new BigInteger[2];
            QR[0] = BigInteger.DivRem(A, B, out QR[1]);
            return QR;
        }

        private static BigInteger[] Divide21(BigInteger A, BigInteger B, int n)
        {
            if (n <= 6000)
                return SmallDivRem(A, B);
            int s = n & 1;
            A <<= s;
            B <<= s;
            n++;
            n >>= 1;
            BigInteger Mask = (BigInteger.One << n) - 1;
            BigInteger B1 = B >> n;
            BigInteger B2 = B & Mask;
            BigInteger[] QR1 = Divide32(A >> (n << 1), A >> n & Mask, B, B1, B2, n);
            BigInteger[] QR2 = Divide32(QR1[1], A & Mask, B, B1, B2, n);
            QR2[0] |= QR1[0] << n;
            QR2[1] >>= s;
            return QR2;
        }

        private static BigInteger[] Divide32(BigInteger A12, BigInteger A3, BigInteger B, BigInteger B1, BigInteger B2, int n)
        {
            BigInteger[] QR = new BigInteger[2];
            if ((A12 >> n) != B1)
                QR = Divide21(A12, B1, n);
            else
            {
                QR[0] = (BigInteger.One << n) - 1;
                QR[1] = A12 + B1 - (B1 << n);
            }
            QR[1] = (QR[1] << n | A3) - BigIntegerMultiply(QR[0], B2, n);
            while (QR[1] < 0)
            {
                QR[0] -= 1;
                QR[1] += B;
            }
            return QR;
        }

    }
}
