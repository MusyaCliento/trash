using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace LibBSP
{
	public class BSP : Dictionary<int, LumpInfo>
	{
		private MapType _mapType;

		private Dictionary<int, ILump> _lumps;

		private BSPReader _reader;

		public BSPReader Reader
		{
			get
			{
				if (_reader == null)
				{
					_reader = new BSPReader();
				}
				return _reader;
			}
			private set
			{
				_reader = value;
			}
		}

		public BSPHeader Header { get; private set; }

		public MapType MapType
		{
			get
			{
				if (_mapType == MapType.Undefined)
				{
					_mapType = Reader.GetVersion();
				}
				return _mapType;
			}
			set
			{
				if (value == MapType.Undefined)
				{
					_lumps = null;
				}
				else if (value != _mapType)
				{
					_lumps = new Dictionary<int, ILump>(GetNumLumps(value));
				}
				_mapType = value;
			}
		}

		public bool BigEndian { get; private set; }

		public Entities Entities
		{
			get
			{
				int indexForLump = Entity.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, Entity.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Entities)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = Entity.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool EntitiesLoaded
		{
			get
			{
				int indexForLump = Entity.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lump<Plane> Planes
		{
			get
			{
				int indexForLump = PlaneExtensions.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, PlaneExtensions.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<Plane>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = PlaneExtensions.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool PlanesLoaded
		{
			get
			{
				int indexForLump = PlaneExtensions.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Textures Textures
		{
			get
			{
				int indexForLump = Texture.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, Texture.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Textures)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = Texture.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool TexturesLoaded
		{
			get
			{
				int indexForLump = Texture.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lump<UIVertex> Vertices
		{
			get
			{
				int indexForLump = VertexExtensions.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, VertexExtensions.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<UIVertex>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = VertexExtensions.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool VerticesLoaded
		{
			get
			{
				int indexForLump = VertexExtensions.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lump<Vector3> Normals
		{
			get
			{
				int indexForNormalsLump = Vector3Extensions.GetIndexForNormalsLump(MapType);
				if (indexForNormalsLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForNormalsLump))
					{
						_lumps.Add(indexForNormalsLump, Vector3Extensions.LumpFactory(Reader.ReadLump(this[indexForNormalsLump]), this, this[indexForNormalsLump]));
					}
					return (Lump<Vector3>)_lumps[indexForNormalsLump];
				}
				return null;
			}
			set
			{
				int indexForNormalsLump = Vector3Extensions.GetIndexForNormalsLump(MapType);
				if (indexForNormalsLump >= 0)
				{
					_lumps[indexForNormalsLump] = value;
				}
			}
		}

		public bool NormalsLoaded
		{
			get
			{
				int indexForNormalsLump = Vector3Extensions.GetIndexForNormalsLump(MapType);
				return LumpLoaded(indexForNormalsLump);
			}
		}

		public Lump<Node> Nodes
		{
			get
			{
				int indexForLump = Node.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, Node.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<Node>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = Node.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool NodesLoaded
		{
			get
			{
				int indexForLump = Node.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lump<TextureInfo> TextureInfo
		{
			get
			{
				int indexForLump = LibBSP.TextureInfo.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, LibBSP.TextureInfo.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<TextureInfo>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = LibBSP.TextureInfo.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool TextureInfoLoaded
		{
			get
			{
				int indexForLump = LibBSP.TextureInfo.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lump<Face> Faces
		{
			get
			{
				int indexForLump = Face.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, Face.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<Face>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = Face.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool FacesLoaded
		{
			get
			{
				int indexForLump = Face.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lump<Leaf> Leaves
		{
			get
			{
				int indexForLump = Leaf.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, Leaf.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<Leaf>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = Leaf.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool LeavesLoaded
		{
			get
			{
				int indexForLump = Leaf.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lump<Edge> Edges
		{
			get
			{
				int indexForLump = Edge.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, Edge.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<Edge>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = Edge.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool EdgesLoaded
		{
			get
			{
				int indexForLump = Edge.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lump<Model> Models
		{
			get
			{
				int indexForLump = Model.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, Model.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<Model>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = Model.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool ModelsLoaded
		{
			get
			{
				int indexForLump = Model.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lump<Brush> Brushes
		{
			get
			{
				int indexForLump = Brush.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, Brush.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<Brush>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = Brush.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool BrushesLoaded
		{
			get
			{
				int indexForLump = Brush.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lump<BrushSide> BrushSides
		{
			get
			{
				int indexForLump = BrushSide.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, BrushSide.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<BrushSide>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = BrushSide.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool BrushSidesLoaded
		{
			get
			{
				int indexForLump = BrushSide.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Textures Materials
		{
			get
			{
				int indexForMaterialLump = Texture.GetIndexForMaterialLump(MapType);
				if (indexForMaterialLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForMaterialLump))
					{
						_lumps.Add(indexForMaterialLump, Texture.LumpFactory(Reader.ReadLump(this[indexForMaterialLump]), this, this[indexForMaterialLump]));
					}
					return (Textures)_lumps[indexForMaterialLump];
				}
				return null;
			}
			set
			{
				int indexForMaterialLump = Texture.GetIndexForMaterialLump(MapType);
				if (indexForMaterialLump >= 0)
				{
					_lumps[indexForMaterialLump] = value;
				}
			}
		}

		public bool MaterialsLoaded
		{
			get
			{
				int indexForMaterialLump = Texture.GetIndexForMaterialLump(MapType);
				return LumpLoaded(indexForMaterialLump);
			}
		}

		public Visibility Visibility
		{
			get
			{
				int indexForLump = Visibility.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, new Visibility(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Visibility)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = Visibility.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool VisibilityLoaded
		{
			get
			{
				int indexForLump = Visibility.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lightmaps Lightmaps
		{
			get
			{
				int indexForLump = Lightmaps.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, new Lightmaps(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lightmaps)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = Lightmaps.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool LightmapsLoaded
		{
			get
			{
				int indexForLump = Lightmaps.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lump<Face> OriginalFaces
		{
			get
			{
				int indexForOriginalFacesLump = Face.GetIndexForOriginalFacesLump(MapType);
				if (indexForOriginalFacesLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForOriginalFacesLump))
					{
						_lumps.Add(indexForOriginalFacesLump, Face.LumpFactory(Reader.ReadLump(this[indexForOriginalFacesLump]), this, this[indexForOriginalFacesLump]));
					}
					return (Lump<Face>)_lumps[indexForOriginalFacesLump];
				}
				return null;
			}
			set
			{
				int indexForOriginalFacesLump = Face.GetIndexForOriginalFacesLump(MapType);
				if (indexForOriginalFacesLump >= 0)
				{
					_lumps[indexForOriginalFacesLump] = value;
				}
			}
		}

		public bool OriginalFacesLoaded
		{
			get
			{
				int indexForOriginalFacesLump = Face.GetIndexForOriginalFacesLump(MapType);
				return LumpLoaded(indexForOriginalFacesLump);
			}
		}

		public Lump<TextureData> TextureData
		{
			get
			{
				int indexForLump = LibBSP.TextureData.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, LibBSP.TextureData.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<TextureData>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = LibBSP.TextureData.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool TextureDataLoaded
		{
			get
			{
				int indexForLump = LibBSP.TextureData.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lump<Displacement> Displacements
		{
			get
			{
				int indexForLump = Displacement.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, Displacement.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<Displacement>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = Displacement.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool DisplacementsLoaded
		{
			get
			{
				int indexForLump = Displacement.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lump<DisplacementVertex> DisplacementVertices
		{
			get
			{
				int indexForLump = DisplacementVertex.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, DisplacementVertex.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<DisplacementVertex>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = DisplacementVertex.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool DisplacementVerticesLoaded
		{
			get
			{
				int indexForLump = DisplacementVertex.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lump<Cubemap> Cubemaps
		{
			get
			{
				int indexForLump = Cubemap.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, Cubemap.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<Cubemap>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = Cubemap.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool CubemapsLoaded
		{
			get
			{
				int indexForLump = Cubemap.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public NumList LeafFaces
		{
			get
			{
				NumList.DataType dataType;
				int indexForLeafFacesLump = NumList.GetIndexForLeafFacesLump(MapType, out dataType);
				if (indexForLeafFacesLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLeafFacesLump))
					{
						_lumps.Add(indexForLeafFacesLump, NumList.LumpFactory(Reader.ReadLump(this[indexForLeafFacesLump]), dataType, this, this[indexForLeafFacesLump]));
					}
					return (NumList)_lumps[indexForLeafFacesLump];
				}
				return null;
			}
			set
			{
				NumList.DataType dataType;
				int indexForLeafFacesLump = NumList.GetIndexForLeafFacesLump(MapType, out dataType);
				if (indexForLeafFacesLump >= 0)
				{
					_lumps[indexForLeafFacesLump] = value;
				}
			}
		}

		public bool LeafFacesLoaded
		{
			get
			{
				NumList.DataType dataType;
				int indexForLeafFacesLump = NumList.GetIndexForLeafFacesLump(MapType, out dataType);
				return LumpLoaded(indexForLeafFacesLump);
			}
		}

		public NumList FaceEdges
		{
			get
			{
				NumList.DataType dataType;
				int indexForFaceEdgesLump = NumList.GetIndexForFaceEdgesLump(MapType, out dataType);
				if (indexForFaceEdgesLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForFaceEdgesLump))
					{
						_lumps.Add(indexForFaceEdgesLump, NumList.LumpFactory(Reader.ReadLump(this[indexForFaceEdgesLump]), dataType, this, this[indexForFaceEdgesLump]));
					}
					return (NumList)_lumps[indexForFaceEdgesLump];
				}
				return null;
			}
			set
			{
				NumList.DataType dataType;
				int indexForFaceEdgesLump = NumList.GetIndexForFaceEdgesLump(MapType, out dataType);
				if (indexForFaceEdgesLump >= 0)
				{
					_lumps[indexForFaceEdgesLump] = value;
				}
			}
		}

		public bool FaceEdgesLoaded
		{
			get
			{
				NumList.DataType dataType;
				int indexForFaceEdgesLump = NumList.GetIndexForFaceEdgesLump(MapType, out dataType);
				return LumpLoaded(indexForFaceEdgesLump);
			}
		}

		public NumList LeafBrushes
		{
			get
			{
				NumList.DataType dataType;
				int indexForLeafBrushesLump = NumList.GetIndexForLeafBrushesLump(MapType, out dataType);
				if (indexForLeafBrushesLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLeafBrushesLump))
					{
						_lumps.Add(indexForLeafBrushesLump, NumList.LumpFactory(Reader.ReadLump(this[indexForLeafBrushesLump]), dataType, this, this[indexForLeafBrushesLump]));
					}
					return (NumList)_lumps[indexForLeafBrushesLump];
				}
				return null;
			}
			set
			{
				NumList.DataType dataType;
				int indexForLeafBrushesLump = NumList.GetIndexForLeafBrushesLump(MapType, out dataType);
				if (indexForLeafBrushesLump >= 0)
				{
					_lumps[indexForLeafBrushesLump] = value;
				}
			}
		}

		public bool LeafBrushesLoaded
		{
			get
			{
				NumList.DataType dataType;
				int indexForLeafBrushesLump = NumList.GetIndexForLeafBrushesLump(MapType, out dataType);
				return LumpLoaded(indexForLeafBrushesLump);
			}
		}

		public Lump<StaticModel> StaticModels
		{
			get
			{
				int indexForLump = StaticModel.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, StaticModel.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<StaticModel>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = StaticModel.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool StaticModelsLoaded
		{
			get
			{
				int indexForLump = StaticModel.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lump<LODTerrain> LODTerrains
		{
			get
			{
				int indexForLump = LODTerrain.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, LODTerrain.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<LODTerrain>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = LODTerrain.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool LODTerrainsLoaded
		{
			get
			{
				int indexForLump = LODTerrain.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public NumList LeafStaticModels
		{
			get
			{
				NumList.DataType dataType;
				int indexForLeafStaticModelsLump = NumList.GetIndexForLeafStaticModelsLump(MapType, out dataType);
				if (indexForLeafStaticModelsLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLeafStaticModelsLump))
					{
						_lumps.Add(indexForLeafStaticModelsLump, NumList.LumpFactory(Reader.ReadLump(this[indexForLeafStaticModelsLump]), dataType, this, this[indexForLeafStaticModelsLump]));
					}
					return (NumList)_lumps[indexForLeafStaticModelsLump];
				}
				return null;
			}
			set
			{
				NumList.DataType dataType;
				int indexForLeafStaticModelsLump = NumList.GetIndexForLeafStaticModelsLump(MapType, out dataType);
				if (indexForLeafStaticModelsLump >= 0)
				{
					_lumps[indexForLeafStaticModelsLump] = value;
				}
			}
		}

		public bool LeafStaticModelsLoaded
		{
			get
			{
				NumList.DataType dataType;
				int indexForLeafStaticModelsLump = NumList.GetIndexForLeafStaticModelsLump(MapType, out dataType);
				return LumpLoaded(indexForLeafStaticModelsLump);
			}
		}

		public Lump<Patch> Patches
		{
			get
			{
				int indexForLump = Patch.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, Patch.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (Lump<Patch>)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = Patch.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool PatchesLoaded
		{
			get
			{
				int indexForLump = Patch.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public Lump<Vector3> PatchVertices
		{
			get
			{
				int indexForPatchVertsLump = Vector3Extensions.GetIndexForPatchVertsLump(MapType);
				if (indexForPatchVertsLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForPatchVertsLump))
					{
						_lumps.Add(indexForPatchVertsLump, Vector3Extensions.LumpFactory(Reader.ReadLump(this[indexForPatchVertsLump]), this, this[indexForPatchVertsLump]));
					}
					return (Lump<Vector3>)_lumps[indexForPatchVertsLump];
				}
				return null;
			}
			set
			{
				int indexForPatchVertsLump = Vector3Extensions.GetIndexForPatchVertsLump(MapType);
				if (indexForPatchVertsLump >= 0)
				{
					_lumps[indexForPatchVertsLump] = value;
				}
			}
		}

		public bool PatchVertsLoaded
		{
			get
			{
				int indexForPatchVertsLump = Vector3Extensions.GetIndexForPatchVertsLump(MapType);
				return LumpLoaded(indexForPatchVertsLump);
			}
		}

		public NumList PatchIndices
		{
			get
			{
				NumList.DataType dataType;
				int indexForPatchIndicesLump = NumList.GetIndexForPatchIndicesLump(MapType, out dataType);
				if (indexForPatchIndicesLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForPatchIndicesLump))
					{
						_lumps.Add(indexForPatchIndicesLump, NumList.LumpFactory(Reader.ReadLump(this[indexForPatchIndicesLump]), dataType, this, this[indexForPatchIndicesLump]));
					}
					return (NumList)_lumps[indexForPatchIndicesLump];
				}
				return null;
			}
			set
			{
				NumList.DataType dataType;
				int indexForPatchIndicesLump = NumList.GetIndexForPatchIndicesLump(MapType, out dataType);
				if (indexForPatchIndicesLump >= 0)
				{
					_lumps[indexForPatchIndicesLump] = value;
				}
			}
		}

		public bool PatchIndicesLoaded
		{
			get
			{
				NumList.DataType dataType;
				int indexForPatchIndicesLump = NumList.GetIndexForPatchIndicesLump(MapType, out dataType);
				return LumpLoaded(indexForPatchIndicesLump);
			}
		}

		public NumList LeafPatches
		{
			get
			{
				NumList.DataType dataType;
				int indexForLeafPatchesLump = NumList.GetIndexForLeafPatchesLump(MapType, out dataType);
				if (indexForLeafPatchesLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLeafPatchesLump))
					{
						_lumps.Add(indexForLeafPatchesLump, NumList.LumpFactory(Reader.ReadLump(this[indexForLeafPatchesLump]), dataType, this, this[indexForLeafPatchesLump]));
					}
					return (NumList)_lumps[indexForLeafPatchesLump];
				}
				return null;
			}
			set
			{
				NumList.DataType dataType;
				int indexForLeafPatchesLump = NumList.GetIndexForLeafPatchesLump(MapType, out dataType);
				if (indexForLeafPatchesLump >= 0)
				{
					_lumps[indexForLeafPatchesLump] = value;
				}
			}
		}

		public bool LeafPatchesLoaded
		{
			get
			{
				NumList.DataType dataType;
				int indexForLeafPatchesLump = NumList.GetIndexForLeafPatchesLump(MapType, out dataType);
				return LumpLoaded(indexForLeafPatchesLump);
			}
		}

		public NumList Indices
		{
			get
			{
				NumList.DataType dataType;
				int indexForIndicesLump = NumList.GetIndexForIndicesLump(MapType, out dataType);
				if (indexForIndicesLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForIndicesLump))
					{
						_lumps.Add(indexForIndicesLump, NumList.LumpFactory(Reader.ReadLump(this[indexForIndicesLump]), dataType, this, this[indexForIndicesLump]));
					}
					return (NumList)_lumps[indexForIndicesLump];
				}
				return null;
			}
			set
			{
				NumList.DataType dataType;
				int indexForIndicesLump = NumList.GetIndexForIndicesLump(MapType, out dataType);
				if (indexForIndicesLump >= 0)
				{
					_lumps[indexForIndicesLump] = value;
				}
			}
		}

		public bool IndicesLoaded
		{
			get
			{
				NumList.DataType dataType;
				int indexForIndicesLump = NumList.GetIndexForIndicesLump(MapType, out dataType);
				return LumpLoaded(indexForIndicesLump);
			}
		}

		public NumList TextureTable
		{
			get
			{
				NumList.DataType dataType;
				int indexForTexTableLump = NumList.GetIndexForTexTableLump(MapType, out dataType);
				if (indexForTexTableLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForTexTableLump))
					{
						_lumps.Add(indexForTexTableLump, NumList.LumpFactory(Reader.ReadLump(this[indexForTexTableLump]), dataType, this, this[indexForTexTableLump]));
					}
					return (NumList)_lumps[indexForTexTableLump];
				}
				return null;
			}
			set
			{
				NumList.DataType dataType;
				int indexForTexTableLump = NumList.GetIndexForTexTableLump(MapType, out dataType);
				if (indexForTexTableLump >= 0)
				{
					_lumps[indexForTexTableLump] = value;
				}
			}
		}

		public bool TextureTableLoaded
		{
			get
			{
				NumList.DataType dataType;
				int indexForTexTableLump = NumList.GetIndexForTexTableLump(MapType, out dataType);
				return LumpLoaded(indexForTexTableLump);
			}
		}

		public NumList DisplacementTriangles
		{
			get
			{
				NumList.DataType dataType;
				int indexForDisplacementTrianglesLump = NumList.GetIndexForDisplacementTrianglesLump(MapType, out dataType);
				if (indexForDisplacementTrianglesLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForDisplacementTrianglesLump))
					{
						_lumps.Add(indexForDisplacementTrianglesLump, NumList.LumpFactory(Reader.ReadLump(this[indexForDisplacementTrianglesLump]), dataType, this, this[indexForDisplacementTrianglesLump]));
					}
					return (NumList)_lumps[indexForDisplacementTrianglesLump];
				}
				return null;
			}
			set
			{
				NumList.DataType dataType;
				int indexForDisplacementTrianglesLump = NumList.GetIndexForDisplacementTrianglesLump(MapType, out dataType);
				if (indexForDisplacementTrianglesLump >= 0)
				{
					_lumps[indexForDisplacementTrianglesLump] = value;
				}
			}
		}

		public bool DisplacementTrianglesLoaded
		{
			get
			{
				NumList.DataType dataType;
				int indexForDisplacementTrianglesLump = NumList.GetIndexForDisplacementTrianglesLump(MapType, out dataType);
				return LumpLoaded(indexForDisplacementTrianglesLump);
			}
		}

		public GameLump GameLump
		{
			get
			{
				int indexForLump = GameLump.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					if (!_lumps.ContainsKey(indexForLump))
					{
						_lumps.Add(indexForLump, GameLump.LumpFactory(Reader.ReadLump(this[indexForLump]), this, this[indexForLump]));
					}
					return (GameLump)_lumps[indexForLump];
				}
				return null;
			}
			set
			{
				int indexForLump = GameLump.GetIndexForLump(MapType);
				if (indexForLump >= 0)
				{
					_lumps[indexForLump] = value;
				}
			}
		}

		public bool GameLumpLoaded
		{
			get
			{
				int indexForLump = GameLump.GetIndexForLump(MapType);
				return LumpLoaded(indexForLump);
			}
		}

		public StaticProps StaticProps
		{
			get
			{
				if (GameLump != null)
				{
					return GameLump.StaticProps;
				}
				return null;
			}
			set
			{
				GameLump.StaticProps = value;
			}
		}

		public bool StaticPropsLoaded
		{
			get
			{
				if (GameLumpLoaded)
				{
					return GameLump.StaticPropsLoaded;
				}
				return false;
			}
		}

		public string MapName { get; set; }

		public Dictionary<int, ILump> Lumps => _lumps;

		public new LumpInfo this[int index]
		{
			get
			{
				if (!ContainsKey(index))
				{
					base[index] = Header.GetLumpInfo(index);
				}
				return base[index];
			}
			private set
			{
				base[index] = value;
			}
		}

		public BSP(string name, MapType mapType = MapType.Undefined)
			: base(GetNumLumps(mapType))
		{
			MapName = name;
			MapType = mapType;
			_lumps = new Dictionary<int, ILump>(GetNumLumps(MapType));
		}

		public BSP(FileInfo file, MapType mapType = MapType.Undefined)
			: base(GetNumLumps(mapType))
		{
			Reader = new BSPReader(file);
			MapName = Path.GetFileNameWithoutExtension(file.FullName);
			MapType = mapType;
			_lumps = new Dictionary<int, ILump>(GetNumLumps(MapType));
			Header = new BSPHeader(this, Reader.GetHeader(MapType));
		}

		public static int GetNumLumps(MapType version)
		{
			if (version == MapType.Titanfall)
			{
				return 128;
			}
			if (version.IsSubtypeOf(MapType.Source))
			{
				return 64;
			}
			if (version.IsSubtypeOf(MapType.Quake))
			{
				return 15;
			}
			if (version.IsSubtypeOf(MapType.MOHAA))
			{
				return 28;
			}
			if (version.IsSubtypeOf(MapType.STEF2))
			{
				return 30;
			}
			if (!version.IsSubtypeOf(MapType.FAKK2))
			{
				switch (version)
				{
				case MapType.SiN:
					break;
				case MapType.Raven:
				case MapType.Nightfire:
					return 18;
				case MapType.Quake2:
					return 19;
				case MapType.Daikatana:
					return 21;
				case MapType.SoF:
					return 22;
				case MapType.CoD:
				case MapType.CoDDemo:
					return 31;
				case MapType.CoD2:
					return 39;
				case MapType.CoD4:
					return 55;
				case MapType.Quake3:
				case MapType.ET:
					return 17;
				default:
					return 0;
				}
			}
			return 20;
		}

		public List<T> GetReferencedObjects<T>(object o, string lumpName)
		{
			if (o == null)
			{
				throw new ArgumentNullException("Object cannot be null.");
			}
			if (lumpName == null)
			{
				throw new ArgumentNullException("Lump name cannot be null.");
			}
			PropertyInfo property = typeof(BSP).GetProperty(lumpName, BindingFlags.Instance | BindingFlags.Public);
			if (property == null)
			{
				throw new ArgumentException("The lump " + lumpName + " does not exist in the BSP class.");
			}
			Type type = o.GetType();
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			PropertyInfo propertyInfo = null;
			PropertyInfo propertyInfo2 = null;
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo3 in array)
			{
				IndexAttribute customAttribute = propertyInfo3.GetCustomAttribute<IndexAttribute>();
				if (customAttribute != null && customAttribute.lumpName == lumpName)
				{
					propertyInfo = propertyInfo3;
					if (propertyInfo != null && propertyInfo2 != null)
					{
						break;
					}
				}
				CountAttribute customAttribute2 = propertyInfo3.GetCustomAttribute<CountAttribute>();
				if (customAttribute2 != null && customAttribute2.lumpName == lumpName)
				{
					propertyInfo2 = propertyInfo3;
					if (propertyInfo != null && propertyInfo2 != null)
					{
						break;
					}
				}
			}
			if (propertyInfo == null || propertyInfo2 == null)
			{
				throw new ArgumentException("An object of type " + type.Name + " does not implement both an Index and Count for lump " + lumpName + ".");
			}
			int num = (int)propertyInfo.GetGetMethod().Invoke(o, null);
			int num2 = (int)propertyInfo2.GetGetMethod().Invoke(o, null);
			IList<T> list = property.GetGetMethod().Invoke(this, null) as IList<T>;
			List<T> list2 = new List<T>(num2);
			for (int j = 0; j < num2; j++)
			{
				list2.Add(list[num + j]);
			}
			return list2;
		}

		public bool LumpLoaded(int index)
		{
			if (_lumps != null)
			{
				return _lumps.ContainsKey(index);
			}
			return false;
		}

		public ILump GetLoadedLump(int index)
		{
			if (!LumpLoaded(index))
			{
				return null;
			}
			return _lumps[index];
		}

		public void UpdateHeader(BSPHeader newHeader)
		{
			Header = newHeader;
			int[] array = base.Keys.ToArray();
			for (int i = 0; i < base.Count; i++)
			{
				int index = array[i];
				this[index] = newHeader.GetLumpInfo(index);
			}
		}
	}
}
