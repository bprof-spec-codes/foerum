export type mockPost={
    id: number,
    category: string,
    image: string,
    date: string,
    title: string,
    comments: mockComment[]
}
  
  export type mockComment={
    id: number,
    image: string,
    modified: boolean,
    answer: number,
    date: string
}

export const getPosts = async(): Promise<mockPost[]>=>await(await fetch('https://fakestoreapi.com/products')).json()

//hívás: const {data, isLoading, error} = useQuery<mockPost[]>('posts',getPosts);