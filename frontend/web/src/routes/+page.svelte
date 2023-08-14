<script lang="ts">
	import { onMount } from 'svelte';
	import { api } from '../api/api';
	import type { User } from '../api/client';

	let response = false;
	let users: User[] = [];
	let jamiro: User[] = [];

	async function refresh() {
		var res = await api.user.login({ email: 'asdf', password: 'asdf' });
		var res2 = await api.user.getAllUser();
		var res3 = await api.user.getjamiro();
		response = res.data;
		users = res2.data;
		jamiro = res3.data;
	}

	onMount(async () => {
		await refresh();
	});
</script>

<div on:click={() => refresh()} class="border">cllick</div>

{#each jamiro as user}
	{user.username}
{/each}
