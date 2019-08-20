using Moq;
using Xunit;
using MDT.UseCase;
using MDT.Model;
using MDT.Model.Gateway;
using MDT.MongoDb;
using System.Collections.Generic;
using System.Linq;
using GenFu;
using System.Threading.Tasks;
using System.IO;


namespace MDT.UseCase.Test
{
    public class HomeUseCaseTest
    {
        public Mock<IEmpleadoRepository> mockEmpleadoRepository = new Mock<IEmpleadoRepository>();

        public HomeUseCase homeUseCase
        {
            get
            {
                return new HomeUseCase(mockEmpleadoRepository.Object);

            }
        }

        [Fact]
        public void GetListaEmpleados()
        {
            //Arrange
            var Empleados = GetFakeEmpleados();
            mockEmpleadoRepository.Setup(repositorio => repositorio.ObtenerListaEmpleados()).Returns(Empleados);

            //Act
            var resultados = homeUseCase.ObtenerListaEmpleados();

            //Assert
            Assert.Equal(resultados.Count, 5);

        }

        private List<Empleado> GetFakeEmpleados()
        {

            IEnumerable<Empleado> empleados = new List<Empleado>();
            var i = 1;

            var items = A.ListOf<int>(5);

            items.ForEach(x =>
            {
                empleados.Append(
                    new Empleado(
                        i.ToString(),
                        "Nombre ",
                        "Apellido "
                        )
                        );
                i++;
            });

            return empleados.ToList();

        }




    }
}