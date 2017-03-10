using System.Linq;
using BaseLibS.Api;
using BaseLibS.Num.Cluster;
using BaseLibS.Num.Matrix;
using NumPluginBase.Distance;
using NUnit.Framework;

namespace BaseLibS.Test
{
    [TestFixture]
    public class ClusteringTest
    {
        [Test]
        public void TestClustering()
        {
            Assert.Inconclusive("DeploymentItem is not available in NUnit");
        }
        /*
        [Test]
        [DeploymentItem(@"Examples", "Examples")]
        public void TestClustering()
        {
            var hclust = new HierarchicalClustering();
            var vals = TestUtils.ReadMatrix("Examples/clustering_array_copy_error.txt.gz");
            var data = new FloatMatrixIndexer(vals);
            var distance = new EuclideanDistance();
            hclust.TreeClusterKmeans(data, MatrixAccess.Columns, distance, HierarchicalClusterLinkage.Average, false,
                false, 1, 300, 1, 10,
                (i) => { });
        }
        */

        [Test]
        public void TestClusterNodeFormat()
        {
             var hclust = new HierarchicalClustering();
            var data = new FloatMatrixIndexer(new float[,] { {1,2,3}, {2,3,4} });
            var distance = new EuclideanDistance();
            var rowTree = hclust.TreeCluster(data, MatrixAccess.Rows, distance, HierarchicalClusterLinkage.Maximum, false,
                false, 1, i => { });
            var rowTreeR = HierarchicalClusterNode.FromRFormat(new[] {-1}, new[] {-2}, new[] {1.732051});
            Assert.AreEqual(rowTreeR[0], rowTree[0]);

            var colTree = hclust.TreeCluster(data, MatrixAccess.Columns, distance, HierarchicalClusterLinkage.Maximum, false,
                false, 1, i => { });
            var colTreeR = HierarchicalClusterNode.FromRFormat(new[] {-1, -3}, new[] {-2, 1}, new[] {1.414214, 2.828428});
            CollectionAssert.AreEqual(colTree, colTreeR);
        }

        [Test]
        public void TestKmedoidClustering()
        {
            var data = new FloatMatrixIndexer(new float[,]
            {
                {2, 6 }, {3, 4 }, {3, 8}, {4, 7}, {6, 2}, {6, 4}, {7, 3}, {7, 4}, {8, 5}, {7, 6}
            });
            var distance = new GenericDistanceMatrix(data, new L1Distance());
            var clustering = KmedoidClustering.GenerateClusters(data, distance, 2);
            Assert.IsTrue(new [] {0, 0, 0, 0, 7, 7, 7, 7, 7, 7}.SequenceEqual(clustering));
        }
    }
}
