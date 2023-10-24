using System.ComponentModel;

namespace Biblioteca
{
  public class GestorBiblioteca
  {
    private BibliotecaContext contexto;

    public GestorBiblioteca()
    {
      contexto = new();
    }

    public void Agregar(Biblioteca b)
    {
      try
      {
        contexto.Bibliotecas.Add(b);
        contexto.SaveChanges();
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }

    public void AgregarLibro(Libro l)
    {
      try
      {
        contexto.Libros.Add(l);
        contexto.SaveChanges();
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }



    //USE [master]
    //GO

    ///****** Object:  Database [Biblioteca]    Script Date: 24/10/2023 12:59:03 ******/
    //CREATE DATABASE [Biblioteca]
    // CONTAINMENT = NONE
    // ON  PRIMARY 
    //( NAME = N'Biblioteca', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Biblioteca.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
    // LOG ON 
    //( NAME = N'Biblioteca_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Biblioteca_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
    // WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
    //GO

    //IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
    //begin
    //EXEC [Biblioteca].[dbo].[sp_fulltext_database] @action = 'enable'
    //end
    //GO

    //ALTER DATABASE [Biblioteca] SET ANSI_NULL_DEFAULT OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET ANSI_NULLS OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET ANSI_PADDING OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET ANSI_WARNINGS OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET ARITHABORT OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET AUTO_CLOSE OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET AUTO_SHRINK OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET AUTO_UPDATE_STATISTICS ON 
    //GO

    //ALTER DATABASE [Biblioteca] SET CURSOR_CLOSE_ON_COMMIT OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET CURSOR_DEFAULT  GLOBAL 
    //GO

    //ALTER DATABASE [Biblioteca] SET CONCAT_NULL_YIELDS_NULL OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET NUMERIC_ROUNDABORT OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET QUOTED_IDENTIFIER OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET RECURSIVE_TRIGGERS OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET  DISABLE_BROKER 
    //GO

    //ALTER DATABASE [Biblioteca] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET DATE_CORRELATION_OPTIMIZATION OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET TRUSTWORTHY OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET ALLOW_SNAPSHOT_ISOLATION OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET PARAMETERIZATION SIMPLE 
    //GO

    //ALTER DATABASE [Biblioteca] SET READ_COMMITTED_SNAPSHOT OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET HONOR_BROKER_PRIORITY OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET RECOVERY FULL 
    //GO

    //ALTER DATABASE [Biblioteca] SET  MULTI_USER 
    //GO

    //ALTER DATABASE [Biblioteca] SET PAGE_VERIFY CHECKSUM  
    //GO

    //ALTER DATABASE [Biblioteca] SET DB_CHAINING OFF 
    //GO

    //ALTER DATABASE [Biblioteca] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
    //GO

    //ALTER DATABASE [Biblioteca] SET TARGET_RECOVERY_TIME = 60 SECONDS 
    //GO

    //ALTER DATABASE [Biblioteca] SET DELAYED_DURABILITY = DISABLED 
    //GO

    //ALTER DATABASE [Biblioteca] SET ACCELERATED_DATABASE_RECOVERY = OFF  
    //GO

    //ALTER DATABASE [Biblioteca] SET QUERY_STORE = ON
    //GO

    //ALTER DATABASE [Biblioteca] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
    //GO

    //ALTER DATABASE [Biblioteca] SET  READ_WRITE 
    //GO



  }
}