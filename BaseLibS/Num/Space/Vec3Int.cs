﻿namespace BaseLibS.Num.Space{
	public class Vec3Int{
		public int x;
		public int y;
		public int z;
		public Vec3Int(){}

		public Vec3Int(int x, int y, int z){
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public void Set(int x1, int y1, int z1){
			x = x1;
			y = y1;
			z = z1;
		}

		public void Set(Vec3Int t1){
			x = t1.x;
			y = t1.y;
			z = t1.z;
		}

		public void Add(Vec3Int t){
			x += t.x;
			y += t.y;
			z += t.z;
		}

		public override bool Equals(object o){
			if (!(o is Vec3Int)){
				return false;
			}
			Vec3Int t = (Vec3Int) o;
			return x == t.x && y == t.y && z == t.z;
		}

		protected bool Equals(Vec3Int other){
			return x == other.x && y == other.y && z == other.z;
		}

		public override int GetHashCode(){
			unchecked{
				int hashCode = x;
				hashCode = (hashCode*397) ^ y;
				hashCode = (hashCode*397) ^ z;
				return hashCode;
			}
		}

		public override string ToString(){
			return "(" + x + ", " + y + ", " + z + ")";
		}
	}
}