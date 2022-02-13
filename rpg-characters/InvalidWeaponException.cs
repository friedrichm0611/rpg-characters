using System;
using System.Runtime.Serialization;

namespace rpg_characters
    {
    [Serializable]
    internal class InvalidWeaponException : Exception
        {
        public InvalidWeaponException()
            {
            Console.WriteLine( "You are not allowed to wear this weapon!" );
            System.Environment.Exit( 1 );
            }

        public InvalidWeaponException( string message ) : base( message )
            {
            Console.WriteLine( "You are not allowed to wear this weapon!" );
            System.Environment.Exit( 1 );
            }

        public InvalidWeaponException( string message, Exception innerException ) : base( message, innerException )
            {
            Console.WriteLine( "You are not allowed to wear this weapon!" );
            System.Environment.Exit( 1 );
            }

        protected InvalidWeaponException( SerializationInfo info, StreamingContext context ) : base( info, context )
            {
            Console.WriteLine( "You are not allowed to wear this weapon!" );
            System.Environment.Exit( 1 );
            }
        }
    }