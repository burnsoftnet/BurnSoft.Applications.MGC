using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BurnSoft.Applications.MGC.hotixes
{
    internal class AccessDatabaseHandler
    {
        public static bool WaitForAccessDatabase(string connectionString, int timeoutSeconds = 60, int retryIntervalMilliseconds = 500)
        {
            DateTime startTime = DateTime.Now;
            
            while ((DateTime.Now - startTime).TotalSeconds < timeoutSeconds)
            {
                try
                {
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();
                        // If we reach here, the database was opened exclusively, meaning it's not in use.
                        connection.Close(); // Close immediately to release the exclusive lock
                        return true;
                    }
                }
                catch (OleDbException ex)
                {
                    // Error code for "file already in use" is often specific to the provider.
                    // For Access, it's typically related to sharing violations.
                    // You might need to inspect ex.ErrorCode or ex.Message for more specific handling.
                    if (ex.Message.Contains("already in use") || ex.Message.Contains("sharing violation"))
                    {
                        // Database is still in use, wait and retry.
                        Thread.Sleep(retryIntervalMilliseconds);
                    }
                    else
                    {
                        // Other unexpected database error.
                        Console.WriteLine($"Unexpected database error: {ex.Message}");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Handle other potential exceptions during connection attempt.
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return false;
                }
            }

            Console.WriteLine($"Timeout: Access database at '{connectionString}' remained in use after {timeoutSeconds} seconds.");
            return false; // Timeout reached, database still in use.
        }
    }
}
