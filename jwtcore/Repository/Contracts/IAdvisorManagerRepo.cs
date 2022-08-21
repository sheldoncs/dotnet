namespace jwtcore.Repository.Contracts
{

   public interface IAdvisorManagerRepo {
       bool SaveChanges();
       string Authenticate(string username, string password);
    
      
   }
    
}